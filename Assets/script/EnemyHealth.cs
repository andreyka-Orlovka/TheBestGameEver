using System;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public float value;

    private void Update()
    {
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
