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

        public float damageBomb;
        
        void Start()
        {
            Invoke("DestroyFireball" , lifetime);
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

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.root.TryGetComponent(out EnemyAI enemyAI))
            {
                enemyAI.Damage(damageBomb);
                                
                DestroyFireball();
            }
        }
    }
}