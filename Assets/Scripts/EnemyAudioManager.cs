using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour {

private AudioSource audio_Source;
[SerializeField]
private AudioClip[] attack_Clips;
[SerializeField]
private AudioClip chase_Clip;
[SerializeField]
private AudioClip dead_Clip;

void Awake()
{
    audio_Source=GetComponent<AudioSource>();
}
public void PlayChaseClip()
{
   // audio_Source.clip=chase_Clip;
    audio_Source.clip=attack_Clips[Random.Range(0,attack_Clips.Length)];
    audio_Source.Play();
} 

public void PlayAttackClip()
{
    audio_Source.clip=attack_Clips[Random.Range(0,attack_Clips.Length)];
    audio_Source.Play();
} 

public void PlayDeadClip()
{
    audio_Source.clip=dead_Clip;
    audio_Source.Play();
} 
	
}
