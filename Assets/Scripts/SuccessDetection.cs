using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessDetection : MonoBehaviour {

private float invoke_After=2f;
void OnTriggerEnter(Collider player)
{
    if(player.tag==Tags.PLAYER_TAG && HealthStatus.enemy_Count==0)
    {
        Invoke("DisplayMissionSuccess",invoke_After);
    }
}
	
void DisplayMissionSuccess()
{
    Cursor.lockState=CursorLockMode.None;
    Cursor.visible=true;
    UnityEngine.SceneManagement.SceneManager.LoadScene("Mission Success");
}
}
