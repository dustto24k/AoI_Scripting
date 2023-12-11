using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class UI_Prop_Television : UI_Popup
{
    private bool _videoInPlay = false;
    private VideoPlayer videoPlayer;

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
        CloseButton
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        transform.Find("Screen").gameObject.BindEvent(PlayPause);
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClosePopup);
        GetImage((int)Images.Progress).gameObject.BindEvent(TrySkip, Define.UIEvent.Pressed);

        videoPlayer = transform.Find("Screen").GetComponent<VideoPlayer>();
        GetText((int)Texts.RTime).text = CalculateTime((int)videoPlayer.frameCount/25);
    }

    private void Update()
    {
        if (videoPlayer.frameCount > 0)
        {
            GetText((int)Texts.LTime).text = CalculateTime((int)videoPlayer.frame/25);
            GetImage((int)Images.Progress).fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
        else if (_videoInPlay)
        {
            _videoInPlay = false;
            videoPlayer.frame = 0;
        }
    }

    private void PlayPause()
    {
        _videoInPlay = _videoInPlay ? false : true;

        if (_videoInPlay) videoPlayer.Play();
        else videoPlayer.Pause();
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
        var skipTo = (float)videoPlayer.frameCount * pct;
        videoPlayer.frame = (long)skipTo;

        videoPlayer.Play();
        _videoInPlay = true;
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