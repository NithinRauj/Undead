using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthStatus : MonoBehaviour {
public float health=100f;
private float destroy_After=3f;
private float invoke_After=3f;
public bool is_Player;
public bool is_Zombie;
[HideInInspector]
public bool is_Dead;
private Animator enemy_Anim;
private Rigidbody rb;
[SerializeField]
private GameObject crosshair;
private NavMeshAgent nav_Mesh_Agent;
private EnemyAudioManager enemy_Audio;
private PlayerStats player_Stats;
public static int enemy_Count=2;
	
void Awake()
{
    if(is_Zombie)
    {
        enemy_Anim=GetComponent<Animator>();
        nav_Mesh_Agent=GetComponent<NavMeshAgent>();
        enemy_Audio=GetComponent<EnemyAudioManager>();
    }
    if(is_Player)
    {
        player_Stats=GetComponent<PlayerStats>();
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
        player_Stats.UpdateHealthStats(health);   
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
        Destroy(nav_Mesh_Agent);
        //below two lines are to disable rigidbody 
        rb.isKinematic=true;
        rb.detectCollisions=false;
        StartCoroutine("PlayEnemyDeadClip");
        Invoke("DestroyEnemyObject",destroy_After);
        enemy_Count--;
    }


    else
    {
        crosshair.SetActive(false);
        GetComponent<CharacterController>().enabled=false;
        GetComponent<PlayerMovementController>().enabled=false;
        GetComponent<PlayerAttack>().enabled=false;
        GetComponent<WeaponManager>().ReturnCurrentWeapon().gameObject.SetActive(false);
        Invoke("DisplayMissionFailureScene",invoke_After);
    }
}

IEnumerator PlayEnemyDeadClip()
{
    yield return new WaitForSeconds(0.3f);
    enemy_Audio.PlayDeadClip();
}

void DestroyEnemyObject()
{
    Destroy(gameObject);
}

void DisplayMissionFailureScene()
{
    Cursor.lockState=CursorLockMode.None;
    Cursor.visible=true;
    UnityEngine.SceneManagement.SceneManager.LoadScene("Mission Failed");
    
}
}
