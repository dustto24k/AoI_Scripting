using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOP : MonoBehaviour
{
    private GameObject _cr;
    private AudioSource audioSource;

    private void Start()
    {
        _cr = GameObject.Find("CameraReticle").transform.GetChild(0).gameObject;
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (PlayerCamera.cActive && transform.position.y > 6.0f) 
             _cr.SetActive(true);
        else _cr.SetActive(false);

        if (PlayerCamera.cActive && transform.position.y < 6.0f)
            AudioActivate();
        else if (transform.position.y < 6.0f) audioSource.Pause();
    }

    private void AudioActivate()
    {

    }

    private void PlayAudio(AudioClip music)
    {
        if (audioSource.isPlaying)
            audioSource.UnPause();
        else
        {
            audioSource.clip = music;
            audioSource.Play();
        }
    }
}