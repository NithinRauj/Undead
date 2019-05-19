using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthStatus : MonoBehaviour {
public float health=100f;
private float destroy_After=3f;
public float invoke_After=3f;
public bool is_Player;
public bool is_Zombie;
private bool is_Dead;
private Animator enemy_Anim;
private Rigidbody rb;
private NavMeshAgent nav_Mesh_Agent;
	
void Awake()
{
    if(is_Zombie)
    {
        enemy_Anim=GetComponent<Animator>();
        nav_Mesh_Agent=GetComponent<NavMeshAgent>();
    }
    rb=GetComponent<Rigidbody>();
}


void Start()
{
    is_Dead=false;
}
public void ApplyDamage(float damage)
{
    if(is_Dead)
      {  return; }
    
    health-=damage;

    if(is_Zombie)
    {
        enemy_Anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    if(is_Player)
    {
        //player health and stats UI is updated here
    }

    if(health<=0f)
    {
        is_Dead=true;
        CharacterDead();
    }
}

void CharacterDead()
{
    if(tag==Tags.ENEMY_TAG)
    {
        enemy_Anim.SetTrigger(AnimationTags.DEAD_TRIGGER);
        //enemy_Anim.enabled=false;
        nav_Mesh_Agent.isStopped=true;
        nav_Mesh_Agent.enabled=false;
        //below two lines are to disable rigidbody 
        rb.isKinematic=true;
        rb.detectCollisions=false;
        Invoke("DestroyEnemyObject",destroy_After);
    }


    else
    {
        GetComponent<CharacterController>().enabled=false;
        GetComponent<PlayerMovementController>().enabled=false;
        Invoke("ResetGame",invoke_After);
    }
}

void DestroyEnemyObject()
{
    Destroy(gameObject);
}

void ResetGame()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene("Level");
}
}
