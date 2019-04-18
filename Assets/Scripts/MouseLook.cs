﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

[SerializeField]
private Transform player_Root,look_Root;
[SerializeField]
private bool invert=false,can_Unlock=true;
[SerializeField]
private float sensitivity=5f;
[SerializeField]
private float smooth_Weight=0.4f;
[SerializeField]
private int smooth_Steps=10;
[SerializeField]
private float roll_Angle=10f;
[SerializeField]
private float roll_Speed=3f;
[SerializeField]
private Vector2 default_Look_Limits=new Vector2(-70f,80f);
private Vector2 look_Angles,current_Mouse_Look,smooth_Move;
private float current_Roll_Angle;
private int last_Look_Frame;



void Start()
{
    Cursor.lockState=CursorLockMode.Locked;
}

void Update()
{
    CursorLockAndUnlock();
    LookAround();
}

void CursorLockAndUnlock()
{
    if(Input.GetKeyDown(KeyCode.Escape)){
        if(Cursor.lockState==CursorLockMode.Locked)
        {Cursor.lockState=CursorLockMode.None;}

        else
        {
            Cursor.lockState=CursorLockMode.Locked;
            Cursor.visible=false;
        }
    }
}

void LookAround()
{
    current_Mouse_Look=new Vector2(Input.GetAxisRaw("Mouse Y"),Input.GetAxisRaw("Mouse X"));
    look_Angles.x+=current_Mouse_Look.x*sensitivity*(invert ? 1f:-1f);
    look_Angles.y+=current_Mouse_Look.y*sensitivity;
    look_Angles.x=Mathf.Clamp(look_Angles.x,default_Look_Limits.x,default_Look_Limits.y);
    /* 
    For rotation about Z axes
    current_Roll_Angle=Mathf.Lerp(current_Roll_Angle,Input.GetAxisRaw("Mouse X")*roll_Angle,
    roll_Speed*Time.deltaTime);
    */
    player_Root.localRotation=Quaternion.Euler(0f,look_Angles.y,0f);
    look_Root.localRotation=Quaternion.Euler(look_Angles.x,0f,current_Roll_Angle);

}


























	
}
