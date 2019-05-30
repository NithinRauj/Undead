using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private WeaponManager weapon_Manager;
    public float rateOfFire=10f;
    private float nextTimeToFire;
    public float range=20f;
    private float damage;
    public float damage_Shotgun=25f;
    public float damage_Assault_Rifle=15f;
    [SerializeField]
    private int bullets_Assault_Rifle=6;
    [SerializeField]
    private int bullets_Shotgun=8;
    private int bullets_current;
    private GameObject crosshair;
    [SerializeField]
    private Animator FPCamera_Anim;

    void Awake()
    {
        weapon_Manager=GetComponent<WeaponManager>();
        crosshair=GameObject.FindGameObjectWithTag(Tags.CROSSHAIR);
    }

    void Start()
    {
        bullets_current=bullets_Assault_Rifle;
        damage=damage_Assault_Rifle;
        GetComponent<WeaponStats>().UpdateBulletsCount(bullets_Assault_Rifle);
    }

    void Update()
    {
        PlayerShoot();
        SteadyAim();
    }

    void PlayerShoot()
    {
        //if current weapon is assault rifle
         if(weapon_Manager.ReturnCurrentWeapon().fire_Type==WeaponFireType.AUTOMATIC)
        {
            bullets_current=bullets_Assault_Rifle;
            GetComponent<WeaponStats>().UpdateCurrentWeaponStats("Assault Rifle");
            GetComponent<WeaponStats>().UpdateBulletsCount(bullets_Assault_Rifle);
            damage=damage_Assault_Rifle;
            if(Input.GetMouseButton(0) && Time.time>nextTimeToFire && bullets_current>0)
            {
                 nextTimeToFire=Time.time+1/rateOfFire;
                 weapon_Manager.ReturnCurrentWeapon().TriggerAttackAnimation();
                  BulletFired();
                  bullets_Assault_Rifle--;
                  GetComponent<WeaponStats>().UpdateBulletsCount(bullets_Assault_Rifle);
            }
        }

        //if current weapon has single fire mode
        else
        {
             if(weapon_Manager.ReturnCurrentWeapon().tag==Tags.AXE_TAG)
                {
                    GetComponent<WeaponStats>().UpdateCurrentWeaponStats("Axe");
                    GetComponent<WeaponStats>().UpdateBulletsCount();
                }
            else
            {
                bullets_current=bullets_Shotgun;
                GetComponent<WeaponStats>().UpdateCurrentWeaponStats("Shotgun");
                GetComponent<WeaponStats>().UpdateBulletsCount(bullets_Shotgun);
                damage=damage_Shotgun;
            }
            if(Input.GetMouseButtonDown(0))
            {
                //if current weapon is axe
                if(weapon_Manager.ReturnCurrentWeapon().tag==Tags.AXE_TAG)
                {
                    weapon_Manager.ReturnCurrentWeapon().TriggerAttackAnimation();
                }
                //if current weapon is shotgun
                else
                {
                    if(bullets_current>0)
                    {
                        weapon_Manager.ReturnCurrentWeapon().TriggerAttackAnimation();
                        BulletFired();
                        bullets_Shotgun--;
                        GetComponent<WeaponStats>().UpdateBulletsCount(bullets_Shotgun);
                    }
                }
            }
        }
    }

    void SteadyAim()
    {
        //If weapon supports steady aim play steady aim animation whe RMB is held
        if(Input.GetMouseButtonDown(1) && weapon_Manager.ReturnCurrentWeapon().aim_Type==WeaponAim.AIM )
        {
            crosshair.SetActive(false);
            FPCamera_Anim.Play(AnimationTags.STEADYAIM_IN);
        }

        //get out of steady aim when RMB is released
        if(Input.GetMouseButtonUp(1))
        {
            FPCamera_Anim.Play(AnimationTags.STEADYAIM_OUT);
            crosshair.SetActive(true);
        }


    }

     void BulletFired()
        {   
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit))
            {
                Debug.Log("Bullet hit "+hit.transform.gameObject.name);
                if(hit.transform.gameObject.tag==Tags.ENEMY_TAG)
                {
                    hit.transform.gameObject.GetComponent<HealthStatus>().ApplyDamage(damage);
                }
            }
        }















}
