using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerFOP : MonoBehaviour
{
    private GameObject _cr;
    private AudioSource audioSource;
    private VideoPlayer videoPlayer;

    private Vector3 _startPos;
    private Vector3 _merObjPos;
    private Vector3 _brcObjPos;
    private Vector3 _scrtrgPos;

    private AudioClip mainBGM;
    private AudioClip _merMusic;
    private AudioClip _brcMusic;

    static public float musicKeep = 0f;

    private void Start()
    {
        _cr = GameObject.Find("CameraReticle").transform.GetChild(0).gameObject;
        audioSource = Camera.main.GetComponent<AudioSource>();
        videoPlayer = GameObject.Find("wall4-2(screen)").transform.GetComponent<VideoPlayer>();

        _startPos = GameObject.Find("StartPos").transform.position;
        _merObjPos = GameObject.Find("mer").transform.position;
        _brcObjPos = GameObject.Find("brachio").transform.position;
        _scrtrgPos = GameObject.Find("ScreenTrigger").transform.position;

        mainBGM = Managers.Sound.GetOrAddAudioClip("Sounds/SeeSaw_AR");
        _merMusic = Managers.Sound.GetOrAddAudioClip("Sounds/Mer_AR");
        _brcMusic = Managers.Sound.GetOrAddAudioClip("Sounds/Brachio_AR");

        audioSource.clip = _brcMusic;
        audioSource.Play(); audioSource.Pause();
        audioSource.clip = _merMusic;
        audioSource.Play(); audioSource.Pause();
        audioSource.clip = mainBGM;
        audioSource.Play();
    }

    private void Update()
    {
        if (PlayerCamera.cActive && transform.position.y > 6.0f) _cr.SetActive(true);
        else _cr.SetActive(false);

        if (PlayerCamera.cActive && transform.position.z > -8.2f && transform.position.y < 6.0f) AudioActivate();
        else if (transform.position.y < 6.0f) audioSource.Pause();

        float _scrDist = Vector3.Distance(transform.position, _scrtrgPos);
        if (_scrDist < 7.3f && transform.position.y < 2.1f) videoPlayer.Play();
        else videoPlayer.Pause();
    }

    private void AudioActivate()
    {
        float _stpDist = Vector3.Distance(transform.position, _startPos);
        float _merDist = Vector3.Distance(transform.position, _merObjPos);
        float _brcDist = Vector3.Distance(transform.position, _brcObjPos);

        if (_merDist < 5f) PlayAudio(_merMusic);
        else if (_brcDist < 5f) PlayAudio(_brcMusic);
        else if (_stpDist < 17.5f) PlayAudio(mainBGM);
        else audioSource.Pause();
    }

    private void PlayAudio(AudioClip music)
    {
        if (audioSource.clip != music) audioSource.clip = music;

        if (audioSource.isPlaying)
        {   
            if (musicKeep != 0f)
            {
                audioSource.time = musicKeep;
                musicKeep = 0f;
            }
            audioSource.UnPause();
        }
        else audioSource.Play();
    }
}