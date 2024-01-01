using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace Shmup
{
    public class EnemySpawer : MonoBehaviour
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 10;
        [SerializeField] float spawnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;

        float spawnTimer;
        int enemiesSpawned;

        void OnValidate ()
        {
            splines = new List<SplineContainer> (GetComponentsInChildren<SplineContainer>());
        }

        void Start ()
        {
            enemyFactory = new EnemyFactory ();
        }

        void Update ()
        {
            spawnTimer += Time.deltaTime;

            if(enemiesSpawned <  maxEnemies && spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer spline = splines[UnityEngine.Random.Range(0, splines.Count)];


            //GameObject enemy = enemyFactory.CreateEnemy(enemyType, spline);
            enemyFactory.CreateEnemy(enemyType, spline);

            enemiesSpawned++;
        }



    }
}
