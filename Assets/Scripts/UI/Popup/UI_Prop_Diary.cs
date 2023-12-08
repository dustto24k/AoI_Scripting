using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Prop_Diary : UI_Popup
{
    private int _pageIdx = 0;

    enum Images
    {
        Page0,
        Page1,
        Page2,
        Page3,
        Page4,
        Page5,
        Page6,
        Page7
    }

    enum Buttons
    {
        PrevButton,
        NextButton,
        CloseButton
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.PrevButton).gameObject.BindEvent(() => _pageIdx--);
        GetButton((int)Buttons.NextButton).gameObject.BindEvent(() => _pageIdx++);
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClosePopup);
    }

    private void Update()
    {
        GetImage((int)Images.Page0).gameObject.SetActive(false);
        GetImage((int)Images.Page1).gameObject.SetActive(false);
        GetImage((int)Images.Page2).gameObject.SetActive(false);
        GetImage((int)Images.Page3).gameObject.SetActive(false);
        GetImage((int)Images.Page4).gameObject.SetActive(false);
        GetImage((int)Images.Page5).gameObject.SetActive(false);
        GetImage((int)Images.Page6).gameObject.SetActive(false);
        GetImage((int)Images.Page7).gameObject.SetActive(false);
        GetImage(_pageIdx).gameObject.SetActive(true);

        if (_pageIdx == 0) GetButton((int)Buttons.PrevButton).gameObject.SetActive(false);
        else if (_pageIdx == 7) GetButton((int)Buttons.NextButton).gameObject.SetActive(false);
        else
        {
            GetButton((int)Buttons.PrevButton).gameObject.SetActive(true);
            GetButton((int)Buttons.NextButton).gameObject.SetActive(true);
        }
    }
}