using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAIController : MonoBehaviour {

private NavMeshAgent agent;
private Transform player;
private Animator anim;
private float visible_Distance=30f;
private float destroy_After=3f;
private HealthStatus health_Status;
public GameObject attack_Point;
private float min_Speed=4f;
private float max_Speed=5.5f;


void Awake()
{
    agent=GetComponent<NavMeshAgent>();
    anim=GetComponent<Animator>();
    player=GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
}

void Start()
{
    agent.speed=Random.Range(min_Speed,max_Speed);
}

void Update()
{
    LocateAndChasePlayer();
}
	
void LocateAndChasePlayer()
{
    if(GetComponent<HealthStatus>().is_Dead)
    {
        return;
    }
    else
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
}

void AttackPlayer()
{
    anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
}

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
