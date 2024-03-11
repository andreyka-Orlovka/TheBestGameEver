using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public float healAmount;

    public GameObject heartGameObject;
    private void OnTriggerEnter(Collider other)
    {
        var playerHp = other.gameObject.GetComponent<PlayerHp>();
        if (playerHp != null)
        {
            Instantiate(heartGameObject, gameObject.transform.position, Quaternion.identity);
            playerHp.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
