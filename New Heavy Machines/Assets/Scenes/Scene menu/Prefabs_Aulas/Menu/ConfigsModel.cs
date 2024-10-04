using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;

[Serializable]

public class ConfigsModel : MonoBehaviour
{
    public Resolution Resolution { get; set; }

    public LimitFPS LimitFPS { get; set; }

    public bool WindowMode { get; set; }

    public bool VSinc {  get; set; }

    public Quality Quality { get; set; }

    public float GlobalVolume { get; set; }

    public float MusicVolume { get; set; }

    public float EffectsVolume { get; set; }

    public bool AutoSave { get; set; }


}
[Serializable]
public enum Quality
{
    Low,
    Medium,
    High
}
[Serializable]
public class Resolution
{
    public int width { get; set; }

    public int height { get; set; }
}
[Serializable]
public class LimitFPS
{
    public bool Limitar { get; set; }

    public bool FPS { get; set; }
}