using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class UI_Prop_Recordplayer : UI_Popup
{
    private int _LPIdx = 0;
    private string[] LPlist = {
        "Gia Margaret - Guitar Piece",
        "Erik Sigurd - The Blue Courtyard",
        "Ryuichi Sakamoto - 20220304",
        "Joel Schoch - Bridge",
        "Fractal Limit, Tatiana Parra, Vardan Ovsepian - That Night",
        "Joel Schoch - More To See",
        "Haruomi Hosono - Memories",
        "Gia Margaret - Ways of Seeing",
        "Erik Sigurd - Sun, mine",
        "아래 이미지를 클릭하면 스트리밍 사이트로 이동합니다"
        };

    enum Images
    {
        LP0,
        LP1,
        LP2,
        LP3,
        LP4,
        LP5,
        LP6,
        LP7,
        LP8,
        LP_PL
    }

    enum Buttons
    {
        PrevButton,
        NextButton,
        CloseButton
    }

    enum Texts
    {
        DescText03
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        GetButton((int)Buttons.PrevButton).gameObject.BindEvent(() => _LPIdx--);
        GetButton((int)Buttons.NextButton).gameObject.BindEvent(() => _LPIdx++);
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClosePopup);
        GetImage((int)Images.LP_PL).gameObject.BindEvent(() => Application.OpenURL("https://music.apple.com/kr/playlist/attic-of-inspiration/pl.u-vxy693XCWlPXjWM"));
    }

    private void Update()
    {
        GetImage((int)Images.LP0).gameObject.SetActive(false);
        GetImage((int)Images.LP1).gameObject.SetActive(false);
        GetImage((int)Images.LP2).gameObject.SetActive(false);
        GetImage((int)Images.LP3).gameObject.SetActive(false);
        GetImage((int)Images.LP4).gameObject.SetActive(false);
        GetImage((int)Images.LP5).gameObject.SetActive(false);
        GetImage((int)Images.LP6).gameObject.SetActive(false);
        GetImage((int)Images.LP7).gameObject.SetActive(false);
        GetImage((int)Images.LP8).gameObject.SetActive(false);
        GetImage((int)Images.LP_PL).gameObject.SetActive(false);
        GetImage(_LPIdx).gameObject.SetActive(true);
        GetText((int)Texts.DescText03).text = $"{LPlist[_LPIdx]}";

        if (_LPIdx == 0) GetButton((int)Buttons.PrevButton).gameObject.SetActive(false);
        else if (_LPIdx == 9) GetButton((int)Buttons.NextButton).gameObject.SetActive(false);
        else
        {
            GetButton((int)Buttons.PrevButton).gameObject.SetActive(true);
            GetButton((int)Buttons.NextButton).gameObject.SetActive(true);
        }
    }
}