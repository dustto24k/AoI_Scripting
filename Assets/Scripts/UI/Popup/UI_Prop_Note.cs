using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Prop_Note : UI_Popup
{
    private int _pageIdx = 0;

    enum Images
    {
        Page01,
        Page02,
        Page03,
        Page04,
        Page05,
        Page06,
        Page07,
        Page08,
        Page09,
        Page10,
        Page11,
        Page12,
        Page13,
        Page14,
        Page15,
        Page16,
        Page17,
        Page18,
        Page19,
        Page20
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
        GetImage((int)Images.Page01).gameObject.SetActive(false);
        GetImage((int)Images.Page02).gameObject.SetActive(false);
        GetImage((int)Images.Page03).gameObject.SetActive(false);
        GetImage((int)Images.Page04).gameObject.SetActive(false);
        GetImage((int)Images.Page05).gameObject.SetActive(false);
        GetImage((int)Images.Page06).gameObject.SetActive(false);
        GetImage((int)Images.Page07).gameObject.SetActive(false);
        GetImage((int)Images.Page08).gameObject.SetActive(false);
        GetImage((int)Images.Page09).gameObject.SetActive(false);
        GetImage((int)Images.Page10).gameObject.SetActive(false);
        GetImage((int)Images.Page11).gameObject.SetActive(false);
        GetImage((int)Images.Page12).gameObject.SetActive(false);
        GetImage((int)Images.Page13).gameObject.SetActive(false);
        GetImage((int)Images.Page14).gameObject.SetActive(false);
        GetImage((int)Images.Page15).gameObject.SetActive(false);
        GetImage((int)Images.Page16).gameObject.SetActive(false);
        GetImage((int)Images.Page17).gameObject.SetActive(false);
        GetImage((int)Images.Page18).gameObject.SetActive(false);
        GetImage((int)Images.Page19).gameObject.SetActive(false);
        GetImage((int)Images.Page20).gameObject.SetActive(false);
        GetImage(_pageIdx).gameObject.SetActive(true);

        if (_pageIdx == 0) GetButton((int)Buttons.PrevButton).gameObject.SetActive(false);
        else if (_pageIdx == 19) GetButton((int)Buttons.NextButton).gameObject.SetActive(false);
        else
        {
            GetButton((int)Buttons.PrevButton).gameObject.SetActive(true);
            GetButton((int)Buttons.NextButton).gameObject.SetActive(true);
        }
    }
}