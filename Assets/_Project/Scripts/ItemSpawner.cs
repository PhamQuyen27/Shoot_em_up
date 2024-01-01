using MEC;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Shmup
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] Item[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] float spawnRadius = 3f;

        CoroutineHandle spawnCoroutine;

        void Start()
        {
            spawnCoroutine =Timing.RunCoroutine(SpawnItems());    
        }

        void OnDestroy()
        {
            Timing.KillCoroutines(spawnCoroutine);
        }

        IEnumerator<float> SpawnItems()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(spawnInterval);
                var item = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
                item.transform.position = (transform.position + Random.insideUnitSphere).With(z: 0) * spawnRadius;
            }
        }
    }
}
