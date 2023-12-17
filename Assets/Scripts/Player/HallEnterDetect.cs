using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallEnterDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MainScene.hallnum++;
        Managers.UI.ShowSceneUI<UI_HallInfo>();
        gameObject.SetActive(false);
    }
}