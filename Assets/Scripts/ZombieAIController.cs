using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAIController : MonoBehaviour {

private NavMeshAgent agent;
[SerializeField]
private Transform player;
private Animator anim;
private float visible_Distance=30f;
private float destroy_After=3f;
public GameObject attack_Point;

void Awake()
{
    agent=GetComponent<NavMeshAgent>();
    anim=GetComponent<Animator>();
}


void Update()
{
    LocateAndChasePlayer();
}
	
void LocateAndChasePlayer()
{
    Vector3 directionToPlayer=player.position-transform.position;
    float angle=Vector3.Angle(transform.forward,directionToPlayer);
    if(directionToPlayer.magnitude<visible_Distance)
    {
        anim.SetBool(AnimationTags.WALK_TRIGGER,true);
        agent.isStopped=false;
        agent.SetDestination(player.position);
        if(directionToPlayer.magnitude<agent.stoppingDistance)
        {
            AttackPlayer();
        }
    }
    else
    {
        anim.SetBool(AnimationTags.WALK_TRIGGER,false);
        agent.isStopped=true;
    }
}

void AttackPlayer()
{
    anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
}

// void ZombieHit()
// {
//     anim.SetTrigger(AnimationTags.HIT_TRIGGER);
//     //insert code for reducing zombie's health here
//     //if health <=0 
//     //ZombieDead();
// }
// void ZombieDead()
// {
//     anim.SetTrigger(AnimationTags.DEAD_TRIGGER);
//     Destroy(gameObject,destroy_After);
// }


public void TurnOnAttackPoint()
    {
        attack_Point.SetActive(true);
    }
	public void TurnOffAttackPoint()
    {
        if(attack_Point.activeInHierarchy)
            attack_Point.SetActive(false);
    }








}
