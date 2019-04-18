using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

private CharacterController characterController;
private Vector3 moveDirection;
public float speed=5f;
private float gravity=20f;
public float jumpForce=10f;
private float verticalVelocity;


void Awake()
{
    characterController=GetComponent<CharacterController>();
}

void Update()
{
    MovePlayer();
}

void MovePlayer()
{
    moveDirection=new Vector3(Input.GetAxis(Axis.HORIZONTAL),0,Input.GetAxis(Axis.VERTICAL));
    moveDirection=transform.TransformDirection(moveDirection);
    moveDirection*=speed*Time.deltaTime;
    characterController.Move(moveDirection);
}
}
