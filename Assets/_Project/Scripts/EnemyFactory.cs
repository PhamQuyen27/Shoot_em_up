using UnityEngine;
using UnityEngine.Splines;

namespace Shmup
{
    public class EnemyFactory 
    {
        public GameObject CreateEnemy (EnemyType enemytype, SplineContainer spline)
        {
            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemytype.enemyPrefab)
                .SetSpline(spline)
                .SetSpeed(enemytype.speed);

            return builder.Build();
        }

    }
}
