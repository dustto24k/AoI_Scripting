using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PropText : UI_Base, IInteractable
{
    enum Texts
    {
        PropDesc,
        InteractInfo
    }

    public override void Init()
    {
        gameObject.SetActive(false);

        Dictionary<string, string> dict = Managers.Data.PropDict;

        Bind<TextMeshProUGUI>(typeof(Texts));

        string _desc = dict[transform.parent.name];
        GetText((int)Texts.PropDesc).text = $"{_desc}";
        GetText((int)Texts.InteractInfo).text = "클릭해서 자세히 보기";
    }

    public void Interact()
    {
        switch (transform.parent.name)
        {
            case ("Note"):
                Managers.UI.ShowPopupUI<UI_Prop_Note>();
                break;

            case ("iMac"):
                Managers.UI.ShowPopupUI<UI_Prop_iMac>();
                break;

            case ("Synthesizer"):
                Managers.UI.ShowPopupUI<UI_Prop_Synthesizer>();
                break;

            case ("AcousticGuitar"):
                Managers.UI.ShowPopupUI<UI_Prop_AcousticGuitar>();
                break;

            case ("Recordplayer"):
                Managers.UI.ShowPopupUI<UI_Prop_Recordplayer>();
                break;

            case ("Diary"):
                Managers.UI.ShowPopupUI<UI_Prop_Diary>();
                break;

            case ("Photo"):
                Managers.UI.ShowPopupUI<UI_Prop_Photo>();
                break;

            case ("Books"):
                Managers.UI.ShowPopupUI<UI_Prop_Books>();
                break;
        }
    }
}