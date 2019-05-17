using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim {NONE,SELF_AIM,AIM}
public enum WeaponFireType {SINGLE,AUTOMATIC}
public enum WeaponBulletType {BULLET,ARROW,NONE}
public class WeaponHandler : MonoBehaviour {
    private Animator anim;
    [SerializeField]
    private AudioSource firing_Sound,reload_Sound;
    public WeaponFireType fire_Type;
    public WeaponAim aim_Type;
    public WeaponBulletType bullet_Type;
    [SerializeField]
    private GameObject muzzle_Flash;
    public GameObject attack_Point;

    void Awake()
    {
        anim=GetComponent<Animator>();
    }

    public void TriggerAttackAnimation()
    {
        anim.SetTrigger(AnimationTags.ATTACK_PARAMETER);
    }

    public void PlayFiringSound()
    {
        firing_Sound.Play();
    }
    public void PlayReloadSound()
    {
        reload_Sound.Play();
    }

    public void TurnOnMuzzleFlash()
    {
        muzzle_Flash.SetActive(true);
    }
    public void TurnOffMuzzleFlash()
    {
        muzzle_Flash.SetActive(false);
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
