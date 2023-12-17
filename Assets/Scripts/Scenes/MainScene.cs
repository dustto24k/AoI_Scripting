using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainScene : BaseScene
{
    static public int hallnum = 0;

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Main;

        PlayerActivate();
        Managers.UI.ShowSceneUI<UI_HallInfo>();

        Transform IPparent = GameObject.Find("InteractableProps").transform;

        float[] scaler = { 8.2f, 0.5f, 0.6f, 1.7f,
                           1.2f, 0.5f, 1.0f, 1.3f, 0.5f };

        for (int i = 0; i < IPparent.childCount; i++)
        {
            GameObject prop = IPparent.GetChild(i).gameObject;
            UI_PropText ui = Managers.UI.MakeWorldSpaceUI<UI_PropText>(prop.transform);
            ui.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * scaler[i];
        }
        Managers.UI.MakeWorldSpaceUI<UI_PropText>(GameObject.Find("mer").transform);
        Managers.UI.MakeWorldSpaceUI<UI_PropText>(GameObject.Find("brachio").transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public override void Clear() { }

    public static void PlayerActivate()
    {
        PlayerCamera.cActive = true;
        PlayerController.pActive = true;
        PlayerInteractor.iActive = true;

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