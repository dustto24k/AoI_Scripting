using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_HallInfo : UI_Scene
{
    private string[] _HD =
    {
        "�ٸ��� ����ȸ�� ���� ���� ȯ���մϴ�",
        "'�ٸ�'�� ���Ͽ�",
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
        GetText((int)Texts.HallNum).text = $">  �� {MainScene.hallnum + 1}��  <";
        GetText((int)Texts.HallDesc).text = $"{_HD[MainScene.hallnum]}";
    }
}