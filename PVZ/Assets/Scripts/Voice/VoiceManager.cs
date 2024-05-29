using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : Singleton<VoiceManager>
{
    public AudioSource[] audioSources => GetComponents<AudioSource>();


    public void Ice()
    {
        audioSources[0].Play();
    }
    public void Doom()
    {
        audioSources[1].Play();
    }
    public void Squash()
    {
        audioSources[2].Play();
    }

    public void Eat()
    {
        audioSources[3].Play();
    }


}
