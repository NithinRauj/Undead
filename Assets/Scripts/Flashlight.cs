using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

private AudioSource audio_Source;
private Light flashlight;
private bool isLightOn;
void Awake()
{
    flashlight=GetComponent<Light>();
    audio_Source=GetComponent<AudioSource>();
}

void Start()
{
    flashlight.enabled=true;
    audio_Source.Play();
    isLightOn=true;
}
void Update()
{
    ToggleFlashlight();
}

void ToggleFlashlight()
{
    if(Input.GetKeyDown(KeyCode.F) && !isLightOn)
    {
        flashlight.enabled=true;
        audio_Source.Play();
        isLightOn=true;
    }
    else if(Input.GetKeyDown(KeyCode.F) && isLightOn)
    {
        flashlight.enabled=false;
        audio_Source.Play();
        isLightOn=false;
    }
}
	
}
