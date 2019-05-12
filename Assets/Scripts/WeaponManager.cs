using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

[SerializeField]
private WeaponHandler[] weapons;
private int current_Weapon_Index=0;

void Start()
{
    weapons[current_Weapon_Index].gameObject.SetActive(true);
}	

void Update()
{
    //if we want to use assault rifle
    if(Input.GetKeyDown(KeyCode.Alpha1))
    {
        TurnOnSelectedWeapon(0);
    }
    //if we want to use shotgun
    if(Input.GetKeyDown(KeyCode.Alpha2))
    {
        TurnOnSelectedWeapon(1);
    }
    //if we want to use axe
    if(Input.GetKeyDown(KeyCode.Alpha3))
    {
        TurnOnSelectedWeapon(2);
    }
}

void TurnOnSelectedWeapon(int weapon_Index)
{
    //condition is used to check wether we draw the selected weapon again
    if(current_Weapon_Index==weapon_Index)
        return;
    weapons[current_Weapon_Index].gameObject.SetActive(false);
    weapons[weapon_Index].gameObject.SetActive(true);
    current_Weapon_Index=weapon_Index;
}

//to refer current weapon methods and fields in this script and other scripts
public WeaponHandler ReturnCurrentWeapon()
{
    return weapons[current_Weapon_Index];
}







}
