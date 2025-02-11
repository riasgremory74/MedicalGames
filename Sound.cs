using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

    public string Name;
    public AudioClip Clip;

    [Range(0f,1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;
    [Range(0, 1f)]
    public float spatialBlend;

    public bool loop;

    

    [HideInInspector]
    public AudioSource Source;
}
