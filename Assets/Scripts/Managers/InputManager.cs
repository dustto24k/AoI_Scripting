using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action FixedKeyAction = null;

    public void OnUpdate()
    {
        if (Input.anyKey == false)
            return;

        if (KeyAction != null)
            KeyAction.Invoke();
    }

    public void OnFixedUpdate()
    {
        if (Input.anyKey == false)
            return;

        if (FixedKeyAction != null)
            FixedKeyAction.Invoke();
    }

    public void Clear()
    {
        FixedKeyAction = null;
    }
}
