using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        MainScene.PlayerDeactivate();
        Managers.UI.SetCanvas(gameObject, true);

        Managers.Input.KeyAction -= EscapeInput;
        Managers.Input.KeyAction += EscapeInput;
    }

    protected void OnClosePopup()
    {
        Managers.Input.KeyAction -= EscapeInput;
        Camera.main.GetComponent<AudioSource>().clip = null;

        Managers.UI.ClosePopupUI(this);
        MainScene.PlayerActivate();
    }

    private void EscapeInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClosePopup();
    }
}