using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct soundEffect
{
    public string groupID;
    public AudioClip[] clips;
}

public class SoundLilbrary : MonoBehaviour
{
    public soundEffect[] soundEffects;

    public AudioClip GetClipFromName(string name)
    {
        foreach (var soundEffect in soundEffects)
        {
            if (soundEffect.groupID == name)
            {
                return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
            }
        }
        return null;
    }
}
