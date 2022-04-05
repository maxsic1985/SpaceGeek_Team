using UnityEngine;
using GeekSpace.CONSTANT;
using GeekSpace.POOL;
using GeekSpace.PROVIDER;
namespace GeekSpace.ENEMY
{
    internal class EnemyPoolFactory
    {
        internal static ObjectPool EnemyPoolCreate(EnemyType enemyType)
        {
            var enemyPrefab = (Resources.Load<EnemyProviderBeh>(PathsManager.ASTEROID_PREFAB));
            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    enemyPrefab = (Resources.Load<EnemyProviderBeh>(PathsManager.ASTEROID_PREFAB));
                    break;
                case EnemyType.Ship:
                    enemyPrefab = (Resources.Load<EnemyProviderBeh>(PathsManager.ENEMY_SHIP_PREFAB));
                    break;
            }
            var poolRoot = new Vector3(0, 0, 0);
            var enemyPool = new ObjectPool(enemyPrefab.gameObject, poolRoot);

            return enemyPool;
        }

    }
}

