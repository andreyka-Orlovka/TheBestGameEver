using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxScale;

    public float speed;

    public float damage;

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    
    void Update()
    {
        transform.localScale += Vector3.one * (Time.deltaTime * speed);
        if (transform.localScale.x > maxScale)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyAI = GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.Damage(damage);
        }

        var playerHP = GetComponent<PlayerHp>();
        if (playerHP != null)
        {
            playerHP.DealDamag(damage);
        }
    }
}
