using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintAndCrouch : MonoBehaviour {

	private PlayerMovementController player_Movement;
    private Transform look_Root;
    public float run_Speed=10f;
    public float move_Speed=5f;
    public float crouch_Speed=2.5f;
    public float stand_Height=2.18f;
    public float crouch_Height=0.61f;
    private bool is_Crouching=false;

    void Awake()
    {
        player_Movement=GetComponent<PlayerMovementController>();
        look_Root=transform.GetChild(0);
    }

    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            player_Movement.speed=run_Speed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            player_Movement.speed=move_Speed;
        }
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(!is_Crouching)
            {
                look_Root.localPosition=new Vector3(0f,crouch_Height,0f);
                is_Crouching=true;
                player_Movement.speed=move_Speed;
            }
            else
            {
                look_Root.localPosition=new Vector3(0f,stand_Height,0f);
                is_Crouching=false; 
                player_Movement.speed=move_Speed;  
            }
        }
    }

















}
