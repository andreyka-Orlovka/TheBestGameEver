
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class FireballCaster : MonoBehaviour
{

    public GameObject fireballPrefab;
    
    public GameObject fireballPrefabElectro;
    
    public GameObject fireballPrefabMithereens;

    public Transform fireballSourceTransform;
    public BombIteme bombIteme;

    private void Start()
    {

        bombIteme = GetComponent<BombIteme>();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bombIteme.getKey1)
        {
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
    }
}
