using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum zombie_State    {IDLE,CHASE,ATTACK,DEAD};
public class ZombieAIController : MonoBehaviour {

private NavMeshAgent agent;
[SerializeField]
private Transform player;
private Animator anim;
private float visible_Angle=60f;
private float visible_Distance=30f;
private zombie_State zombie_State;

void Awake()
{
    agent=GetComponent<NavMeshAgent>();
    anim=GetComponent<Animator>();
}

void Start()
{
    zombie_State=zombie_State.IDLE;
}

void Update()
{
    LocateAndChasePlayer();
}
	
void LocateAndChasePlayer()
{
    Vector3 directionToPlayer=player.position-transform.position;
    float angle=Vector3.Angle(transform.forward,directionToPlayer);
    if(directionToPlayer.magnitude<visible_Distance && angle<visible_Angle)
    {
        agent.isStopped=false;
        agent.SetDestination(player.position);
        if(directionToPlayer.magnitude<agent.stoppingDistance)
        {
            AttackPlayer();
        }
    }
    else
    {
        agent.isStopped=true;
    }
}

void AttackPlayer()
{
    anim.SetBool(AnimationTags.ATTACK_TRIGGER,true);
}

















}
