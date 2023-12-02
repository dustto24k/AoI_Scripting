using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ŵ������� InteractableProps ���� ���� GameObject�鿡�� MakeWorldspaceUI(child.transform, UI_PropText)�� �ǰԲ� �ؾ�.

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