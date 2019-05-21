using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

[SerializeField]
private Image health_Stats;
[SerializeField]
private Image stamina_Stats;

public void UpdateHealthStats(float health_Value)
{
    health_Value/=100;
    health_Stats.fillAmount=health_Value;
}

public void UpdateStaminaStats(float stamina_Value)
{
    stamina_Value/=100;
    stamina_Stats.fillAmount=stamina_Value;
}
}
