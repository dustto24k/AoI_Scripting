using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static T GetorAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    {
        return Util.GetorAddComponent<T>(go);
    }

    public static void BindEvent(this GameObject go, Action action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go, action, type);
    }
}
