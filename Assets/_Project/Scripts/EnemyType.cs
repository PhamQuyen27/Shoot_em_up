using UnityEngine;

namespace Shmup
{
    [CreateAssetMenu(fileName ="EnemyType", menuName ="Shump/EnemyType", order = 0)]
    public class EnemyType :ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed = 2f;

    }
}
