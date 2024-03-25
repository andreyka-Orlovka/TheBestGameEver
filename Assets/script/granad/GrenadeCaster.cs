using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenade;
    public Transform GrenadeTransform;
    public float force = 400;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var Grenade = Instantiate(grenade);
            Grenade.transform.position = GrenadeTransform.position;
            Grenade.GetComponent<Rigidbody>().AddForce(GrenadeTransform.forward * force);
        }
    }
}
