using UnityEngine;

namespace Shmup
{
    public class HealItem : Item
    {
        void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                other.GetComponent<Player>().AddHealth((int)amount);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Collider 'other' is null!");
            }
        }
    }
}
