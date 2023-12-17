using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_Mer : UI_Popup
{
    enum Buttons
    {
        CloseButton
    }

    private Transform _obj;
    private float rotSpd = 1f;
    private Vector2 mPivot;
    private bool isRotate = false;

    private AudioListener audioListener;
    private AudioSource audioSource;
    private AudioClip music;
    private float musicTime;

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClosePopup);

        _obj = transform.GetChild(1).GetChild(0).transform;

        audioListener = GameObject.Find("CanvasCamera").GetComponent<AudioListener>();
        audioSource = GameObject.Find("CanvasCamera").GetComponent<AudioSource>();
        audioListener.enabled = true;
        audioSource.enabled = true;

        music = Managers.Sound.GetOrAddAudioClip("Sounds/Mer_AR");
        musicTime = Camera.main.GetComponent<AudioSource>().time;

        audioSource.clip = music;
        audioSource.Play();
        audioSource.time = musicTime;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotate = true;
            mPivot = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
            isRotate = false;

        if (isRotate)
        {
            Vector2 curPos = Input.mousePosition;
            float rotX = curPos.x - mPivot.x;
            float rotY = curPos.y - mPivot.y;

            _obj.transform.Rotate(Vector3.up, -rotX * rotSpd);
            _obj.transform.Rotate(Vector3.right, rotY * rotSpd);
            mPivot = curPos;
        }
    }

    protected new void OnClosePopup()
    {
        base.OnClosePopup();

        PlayerFOP.musicKeep = audioSource.time;
        audioListener.enabled = false;
        audioSource.enabled = false;
    }
}