using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_BagStandUp : UI_Scene
{
    public override void Init()
    {
        base.Init();
        Destroy(gameObject, 3);
    }
}