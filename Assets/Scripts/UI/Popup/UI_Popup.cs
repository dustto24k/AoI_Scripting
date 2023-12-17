using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        MainScene.PlayerDeactivate();
        Managers.UI.SetCanvas(gameObject, true);
    }

    protected void OnClosePopup()
    {
        if (GameObject.Find("Player").transform.position.y > 6.0f)
            Camera.main.GetComponent<AudioSource>().clip = null;

        Managers.UI.ClosePopupUI(this);
        MainScene.PlayerActivate();
    }
}