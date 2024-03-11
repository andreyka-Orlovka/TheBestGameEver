
using TMPro;

using UnityEngine;


public class FireballCaster : MonoBehaviour
{

    public GameObject fireballPrefab;
    
    public Transform fireballSourceTransform;


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            
        }

        
    }
}
