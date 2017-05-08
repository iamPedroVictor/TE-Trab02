using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundControl : MonoBehaviour{

    public AudioSource audioSource;
    public ClipsStruct[] Clips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ApplySound(string soundType){
        for(int i = 0; i < Clips.Length; i++)
        {
            if(Clips[i].ClipName == soundType)
            {
                audioSource.clip = Clips[i].AudioClip;
                break;
            }
        }
        audioSource.Play();
    }

}

[System.Serializable]
public struct ClipsStruct
{
    public string ClipName;
    public AudioClip AudioClip;
}