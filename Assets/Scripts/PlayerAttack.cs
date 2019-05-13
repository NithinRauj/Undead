using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private WeaponManager weapon_Manager;
    private float rateOfFire=15f;
    private float nextTimeToFire;
    public float range=20f;
    private float damage=20f;
    private GameObject crosshair;
    [SerializeField]
    private Animator FPCamera_Anim;

    void Awake()
    {
        weapon_Manager=GetComponent<WeaponManager>();
        crosshair=GameObject.FindGameObjectWithTag(Tags.CROSSHAIR);
        // FPCamera_Anim=transform.Find(Tags.LOOK_ROOT).
        //    transform.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();
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
            if(Input.GetMouseButton(0) && Time.time>nextTimeToFire)
            {
                 nextTimeToFire=Time.time+1/rateOfFire;
                 weapon_Manager.ReturnCurrentWeapon().TriggerAttackAnimation();
                  BulletFired();
            }
        }

        //if current weapon has single fire mode
        else
        {
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
                    weapon_Manager.ReturnCurrentWeapon().TriggerAttackAnimation();
                    BulletFired();
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
            }
        }















}
