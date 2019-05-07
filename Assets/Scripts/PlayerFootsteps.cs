using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

	private AudioSource footsteps_Source;
    [SerializeField]
    private AudioClip[] footsteps_Clip;
    private CharacterController character_Controller;
    [HideInInspector]
    public float vol_Min,vol_Max;
    private float accumulated_Distance;
    [HideInInspector]
    public float step_Distance;

    void Awake()
    {
        character_Controller=GetComponentInParent<CharacterController>();
        footsteps_Source=GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckToPlayFootstepSound();
    }

    void CheckToPlayFootstepSound()
    {
        if(!character_Controller.isGrounded)
        {return;}
        else
        {
            if(character_Controller.velocity.sqrMagnitude>0)
            {
                //accumulated_Distance is the minimum distance to be covered to trigger footstep sound
                accumulated_Distance+=Time.deltaTime;
                if(accumulated_Distance>step_Distance)
                {
                    footsteps_Source.volume=Random.Range(vol_Min,vol_Max);
                    footsteps_Source.clip=footsteps_Clip[Random.Range(0,footsteps_Clip.Length)];
                    footsteps_Source.Play();
                    accumulated_Distance=0f;
                }
            }
            else
                {
                    accumulated_Distance=0f;
                }
        }
    }
}
