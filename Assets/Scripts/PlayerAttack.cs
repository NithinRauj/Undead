using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private WeaponManager weapon_Manager;
    private float rateOfFire=15f;
    private float nextTimeToFire;
    private float damage=20f;

    void Start()
    {
        weapon_Manager=GetComponent<WeaponManager>();
    }

    void Update()
    {
        PlayerShoot();
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
                
                else
                {
                    weapon_Manager.ReturnCurrentWeapon().TriggerAttackAnimation();
                    //BulletFired();
                }
            }
        }
    }
}
