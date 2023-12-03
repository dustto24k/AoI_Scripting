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

        Transform IPparent = GameObject.Find("InteractableProps").transform;

        for (int i = 0; i < IPparent.childCount; i++)
        {
            GameObject prop = IPparent.GetChild(i).gameObject;
            Managers.UI.MakeWorldSpaceUI<UI_PropText>(prop.transform);
        }
    }

    public override void Clear()
    {
        
    }
}
