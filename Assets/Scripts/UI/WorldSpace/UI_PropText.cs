using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PropText : UI_Base, IInteractable
{
    enum GameObjects
    {
        PropDesc,
        InteractInfo
    }

    public override void Init()
    {
        gameObject.SetActive(false);

        Dictionary<string, string> dict = Managers.Data.PropDict;

        Bind<GameObject>(typeof(GameObjects));

        string _desc = dict[transform.parent.name];
        GetObject((int)GameObjects.PropDesc).GetComponent<TextMeshProUGUI>().text = $"{_desc}";
        GetObject((int)GameObjects.InteractInfo).GetComponent<TextMeshProUGUI>().text = "click to interact";
    }

    public void Interact()
    {
        Debug.Log($"{GetObject((int)GameObjects.PropDesc).GetComponent<TextMeshProUGUI>().text}");
    }
}