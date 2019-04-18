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
    moveDirection=new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
    moveDirection=transform.TransformDirection(moveDirection);
    moveDirection*=speed*Time.deltaTime;
    ApplyGravity();
    characterController.Move(moveDirection);
}

void ApplyGravity()
{
    if(characterController.isGrounded)
    {
        verticalVelocity-=gravity*Time.deltaTime;
        PlayerJump();
    }
    else
    {
        verticalVelocity-=gravity*Time.deltaTime;
    }
    moveDirection.y=verticalVelocity*Time.deltaTime;
}

void PlayerJump()
{
    if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
        verticalVelocity=jumpForce;
    }
}
}
