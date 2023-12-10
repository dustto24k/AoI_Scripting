using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Main;

        PlayerActivate();

        Transform IPparent = GameObject.Find("InteractableProps").transform;

        float[] scaler = { 8.2f, 0.5f, 0.6f, 1.7f,
                           1.2f, 0.5f, 1.0f, 1.3f, 0.5f };

        for (int i = 0; i < IPparent.childCount; i++)
        {
            GameObject prop = IPparent.GetChild(i).gameObject;
            UI_PropText ui = Managers.UI.MakeWorldSpaceUI<UI_PropText>(prop.transform);
            ui.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * scaler[i];
        }
    }

    public override void Clear()
    {
    }

    public static void PlayerActivate()
    {
        PlayerCamera.cActive = true;
        PlayerController.pActive = true;
        PlayerInteractor.iActive = true;
        GameObject.Find("CameraReticle").transform.GetChild(0).gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void PlayerDeactivate()
    {
        PlayerCamera.cActive = false;
        PlayerController.pActive = false;
        PlayerInteractor.iActive = false;
        GameObject.Find("CameraReticle").transform.GetChild(0).gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}