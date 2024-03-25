using UnityEngine;

namespace script
{
    public abstract class EnemyHealth : MonoBehaviour
    {
        public float value;

        public PlayerProgress playerProgress;

        public void DealDamage(float damage)
        {
            playerProgress.AddExperience(damage);
            if (value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
