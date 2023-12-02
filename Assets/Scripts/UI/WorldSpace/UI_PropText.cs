using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 씬매니저에서 InteractableProps 폴더 내의 GameObject들에게 MakeWorldspaceUI(child.transform, UI_PropText)가 되게끔 해야.

public class UI_PropText : UI_Base, IInteractable
{
    enum GameObjects
    {
        PropDesc,
        InteractInfo
    }

    public override void Init()
    {
        Dictionary<string, string> dict = Managers.Data.PropDict;

        Bind<GameObject>(typeof(GameObjects));
        string _desc = dict[transform.parent.name];
        GetText((int)GameObjects.PropDesc).text = $"{_desc}";
        GetText((int)GameObjects.InteractInfo).text = "click to interact";
    }

    public void Interact()
    {
        Debug.Log($"{GameObjects.PropDesc}");
    }
}