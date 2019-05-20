using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAudioManager : MonoBehaviour {

public AudioSource audio_Source;
public AudioClip[] audio_Clips;


void PlayAxeSounds()
{
    audio_Source.clip=audio_Clips[Random.Range(0,audio_Clips.Length)];
    audio_Source.Play();
}
	
}
