using System;
using UnityEngine;
using Object = System.Object;

namespace script
{
    public class ExampleClass : MonoBehaviour
    {
        public float speed;

        public float lifetime;

        public GameObject bom;

        public float damage;
        
        
        void Start()
        {
            

            Invoke("DestroyFireball" , lifetime);
            Invoke("Bom" , lifetime);
        }
        private void FixedUpdate()
        {
            MoveFixedUpdate();
        }
        private void MoveFixedUpdate()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        private void DestroyFireball()
        {
            Instantiate(bom, gameObject.transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (EnemyHealth != null)
            {
                EnemyHealth.value -= damage;
                
                DestroyFireball();
            }
            
            
        }
    }
}