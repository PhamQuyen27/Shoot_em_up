using UnityEngine;

namespace Shmup
{
    public class FuelItem : Item
    {
        void OnTriggerEnter(Collider other)
        {
/*            other.GetComponent<Player>().AddFuel((int) amount);
            Destroy(gameObject);*/
            if (other != null)
            {
                other.GetComponent<Player>().AddFuel((int)amount);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Collider 'other' is null!");
            }
        }
    }
}
