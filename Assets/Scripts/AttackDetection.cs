using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour {

public float radius=1f;
public float damage=10f;
public LayerMask layer_Mask;

void Update()
{
    Collider[] hits=Physics.OverlapSphere(transform.position,radius,layer_Mask);
    if(hits.Length>0)
    {
        Debug.Log(hits[0].gameObject.name+" got hit");
        hits[0].gameObject.GetComponent<HealthStatus>().ApplyDamage(damage);
        gameObject.SetActive(false);
    }
}
}
