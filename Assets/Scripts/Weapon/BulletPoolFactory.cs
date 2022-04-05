using UnityEngine;
using GeekSpace.CONSTANT;
using GeekSpace.POOL;
using GeekSpace.PROVIDER;

namespace GeekSpace
{
    internal class BulletPoolFactory
    {
        internal static ObjectPool BulletPoolCreate(WeaponType weaponType)
        {
            var bulletPrefab = (Resources.Load<BulletProviderBeh>(PathsManager.BULLET_PREFAB));
            switch (weaponType)
            {
                case WeaponType.ChainGunMk1:
                    bulletPrefab = (Resources.Load<BulletProviderBeh>(PathsManager.BULLET_PREFAB));
                    break;
                case WeaponType.LaserGunMk1:
                    bulletPrefab = (Resources.Load<BulletProviderBeh>(PathsManager.BULLET_PREFAB));
                    break;
            }


            var poolRoot = new Vector3(0, 0, 0);
            var bulletPool = new ObjectPool(bulletPrefab.gameObject, poolRoot);

            return bulletPool;
        }
    }
}
