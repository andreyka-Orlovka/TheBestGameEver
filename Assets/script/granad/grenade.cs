using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float delay;

    public GameObject exploitPrefab;
    
    private void OnCollisionEnter(Collision other)
    {
        Invoke("Exploint", delay);
    }

    public void Exploint()
    {
        Destroy(gameObject);
        var exploint= Instantiate(exploitPrefab);
        exploint.transform.position = transform.position;
    }
}
