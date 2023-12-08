using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Prop_Photo : UI_Popup
{
    enum Buttons
    {
        CloseButton
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        GetButton((int)Buttons.CloseButton).gameObject.BindEvent(OnClosePopup);
    }
}