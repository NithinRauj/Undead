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
    private PlayerFootsteps player_Footsteps;
    private float walk_Volume_Min=0.2f,walk_Volume_Max=0.6f;
    private float sprint_Volume=1f;
    private float crouch_Volume=0.1f;
    private float walk_Step_Distance=0.4f;
    private float sprint_Step_Distance=0.25f;
    private float crouch_Step_Distance=0.5f;
    private PlayerStats player_Stats;
    private float sprint_Value=100f;
    private float sprint_Threshold=10f;
    private CharacterController character_Controller;

    void Awake()
    {
        player_Movement=GetComponent<PlayerMovementController>();
        look_Root=transform.GetChild(0);
        player_Footsteps=GetComponentInChildren<PlayerFootsteps>();
        player_Stats=GetComponent<PlayerStats>();
        character_Controller=GetComponent<CharacterController>();
    }

    void Start()
    {
        player_Footsteps.vol_Min=walk_Volume_Min;
        player_Footsteps.vol_Max=walk_Volume_Max;
        player_Footsteps.step_Distance=walk_Step_Distance;
    }

    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        if(sprint_Value>0f)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
            {
                player_Movement.speed=run_Speed;
                player_Footsteps.vol_Min=sprint_Volume;
                player_Footsteps.vol_Max=sprint_Volume;
                player_Footsteps.step_Distance=sprint_Step_Distance;
            }
        }

        if(Input.GetKey(KeyCode.LeftShift) && !is_Crouching && character_Controller.velocity.sqrMagnitude>0f)
        {
            sprint_Value-=sprint_Threshold*Time.deltaTime;
            player_Stats.UpdateStaminaStats(sprint_Value);
            if(sprint_Value<=0f)
            {
                sprint_Value=0f;
                player_Movement.speed=move_Speed;
                player_Footsteps.vol_Min=walk_Volume_Min;
                player_Footsteps.vol_Max=walk_Volume_Max;
                player_Footsteps.step_Distance=walk_Step_Distance;

            }
        }
        else
        {
            sprint_Value+=(sprint_Threshold/2)*Time.deltaTime;
            player_Stats.UpdateStaminaStats(sprint_Value);
            if(sprint_Value>100f)
            {
                sprint_Value=100f;
            }
        }
            if(Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
            {
                player_Movement.speed=move_Speed;
                player_Footsteps.vol_Min=walk_Volume_Min;
                player_Footsteps.vol_Max=walk_Volume_Max;
                player_Footsteps.step_Distance=walk_Step_Distance;
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
                player_Footsteps.vol_Min=crouch_Volume;
                player_Footsteps.vol_Max=crouch_Volume;
                player_Footsteps.step_Distance=crouch_Step_Distance;
            }
            else
            {
                look_Root.localPosition=new Vector3(0f,stand_Height,0f);
                is_Crouching=false; 
                player_Movement.speed=move_Speed;  
                player_Footsteps.vol_Min=walk_Volume_Min;
                player_Footsteps.vol_Max=walk_Volume_Max;
                player_Footsteps.step_Distance=walk_Step_Distance;
            }
        }
    }

















}
