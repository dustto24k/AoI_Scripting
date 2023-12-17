using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_HallInfo : UI_Scene
{
    private string[] _HD =
    {
        "다린의 전시회에 오신 것을 환영합니다",
        "'다린'에 대하여",
        "Brachio & Mer",
        "MV Theatre"
    };

    enum Texts
    {
        HallNum,
        HallDesc
    }

    public override void Init()
    {
        base.Init();
        Destroy(gameObject, 3);

        Bind<TextMeshProUGUI>(typeof(Texts));
        GetText((int)Texts.HallNum).text = $">  제 {MainScene.hallnum + 1}관  <";
        GetText((int)Texts.HallDesc).text = $"{_HD[MainScene.hallnum]}";
    }
}