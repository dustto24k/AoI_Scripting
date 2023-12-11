using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        MainScene.PlayerDeactivate();
        Managers.UI.SetCanvas(gameObject, true);

        //Managers.GetInput.KeyAction -= EscapeInput;
        //Managers.GetInput.KeyAction += EscapeInput;
    }

    protected void OnClosePopup()
    {
        // Managers.GetInput.KeyAction -= EscapeInput;
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