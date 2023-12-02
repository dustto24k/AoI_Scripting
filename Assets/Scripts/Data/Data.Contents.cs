using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Prop

[Serializable]
public class Prop
{
    public string name;
    public string desc;
}

[Serializable]
public class PropText : ILoader<string, string>
{
    public List<Prop> props = new List<Prop>();

    public Dictionary<string, string> MakeDict()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (Prop prop in props)
            dict.Add(prop.name, prop.desc);
        return dict;
    }
}
#endregion