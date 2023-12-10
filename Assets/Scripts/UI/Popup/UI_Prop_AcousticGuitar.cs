using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Prop_AcousticGuitar : UI_Popup
{
    private bool _musicInPlay = false;
    private AudioSource audioSource;
    private AudioClip music;
    private float musicLen;

    enum Texts
    {
        LTime,
        RTime
    }

    enum Images
    {
        Progress
    }

    enum Buttons
    {
        MusicplayerButton,
        CloseButton
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        GetButton((int)Buttons.MusicplayerButton).gameObject.BindEvent(PlayPause);
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClosePopup);
        GetImage((int)Images.Progress).gameObject.BindEvent(TrySkip, Define.UIEvent.Pressed);

        music = Managers.Sound.GetOrAddAudioClip("Sounds/Mer_Inst");
        musicLen = music.length;

        GetText((int)Texts.RTime).text = CalculateTime((int)musicLen);

        audioSource = Camera.main.GetComponent<AudioSource>();
        audioSource.clip = music;
    }

    private void Update()
    {
        GetButton((int)Buttons.MusicplayerButton).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GetButton((int)Buttons.MusicplayerButton).gameObject.transform.GetChild(1).gameObject.SetActive(false);

        if (_musicInPlay)
            GetButton((int)Buttons.MusicplayerButton).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        else
            GetButton((int)Buttons.MusicplayerButton).gameObject.transform.GetChild(0).gameObject.SetActive(true);

        if (audioSource.isPlaying)
        {
            GetText((int)Texts.LTime).text = CalculateTime((int)audioSource.time);
            GetImage((int)Images.Progress).fillAmount = (float)audioSource.time / musicLen;
        }
        else if (_musicInPlay)
        {
            _musicInPlay = false;
            audioSource.time = 0;
        }
    }

    private void PlayPause()
    {
        _musicInPlay = _musicInPlay ? false : true;

        if (audioSource.isPlaying)
        {
            if (_musicInPlay) audioSource.UnPause();
            else audioSource.Pause();
        }
        else
        {
            if (_musicInPlay) audioSource.Play();
        }
    }

    private void TrySkip()
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(GetImage((int)Images.Progress).rectTransform,
            Input.mousePosition, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(GetImage((int)Images.Progress).rectTransform.rect.xMin,
                GetImage((int)Images.Progress).rectTransform.rect.xMax, localPoint.x);

            if (pct < 0.99f)
                SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        var skipTo = musicLen * pct;
        audioSource.time = (long)skipTo;

        if (audioSource.isPlaying ) audioSource.UnPause();
        else audioSource.Play();

        _musicInPlay = true;
    }

    private string CalculateTime(int totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60);
        int tmp = Mathf.FloorToInt(totalSeconds % 60);

        string seconds = "";

        if (tmp < 10) seconds += "0";
        seconds += tmp;

        string result = minutes + ":" + seconds;
        return result;
    }
}