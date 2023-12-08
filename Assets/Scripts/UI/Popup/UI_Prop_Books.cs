using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Prop_Books : UI_Popup
{
    private int _bookIdx = 0;

    enum Images
    {
        Book0,
        Book1,
        Book2,
        Book3,
        Book4
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
        GetButton((int)Buttons.PrevButton).gameObject.BindEvent(() => _bookIdx--);
        GetButton((int)Buttons.NextButton).gameObject.BindEvent(() => _bookIdx++);
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClosePopup);
    }

    private void Update()
    {
        GetImage((int)Images.Book0).gameObject.SetActive(false);
        GetImage((int)Images.Book1).gameObject.SetActive(false);
        GetImage((int)Images.Book2).gameObject.SetActive(false);
        GetImage((int)Images.Book3).gameObject.SetActive(false);
        GetImage((int)Images.Book4).gameObject.SetActive(false);
        GetImage(_bookIdx).gameObject.SetActive(true);

        if (_bookIdx == 0) GetButton((int)Buttons.PrevButton).gameObject.SetActive(false);
        else if (_bookIdx == 4) GetButton((int)Buttons.NextButton).gameObject.SetActive(false);
        else
        {
            GetButton((int)Buttons.PrevButton).gameObject.SetActive(true);
            GetButton((int)Buttons.NextButton).gameObject.SetActive(true);
        }
    }
}