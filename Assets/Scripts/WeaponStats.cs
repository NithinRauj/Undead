using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStats : MonoBehaviour {

[SerializeField]
private Text bullets_Text;
[SerializeField]
private Text current_Weapon_Text;

public void UpdateCurrentWeaponStats(string current_Weapon)
{
    current_Weapon_Text.text=current_Weapon;
}

public void UpdateBulletsCount(int bullets)
{
    bullets_Text.text=bullets.ToString();
}

public void UpdateBulletsCount()
{
    bullets_Text.text="∞";
}
}
