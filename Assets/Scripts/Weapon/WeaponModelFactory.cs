using GeekSpace.CONSTANT;
using GeekSpace.MODEL;
namespace GeekSpace
{
    internal class WeaponModelFactory
    {
        internal  static WeaponModel WeaponModelCreate(WeaponType weaponType)
        {
            var cooldown = WeaponParametrsManager.DEFAULT_RELOAD_COOLDOWN;
            var damage = WeaponParametrsManager.DEFAULT_DAMAGE;
            
            switch (weaponType)
            {
                case WeaponType.ChainGunMk1:
                    damage = WeaponParametrsManager.DEFAULT_DAMAGE;
                    cooldown = WeaponParametrsManager.DEFAULT_RELOAD_COOLDOWN;
                    break;
                case WeaponType.LaserGunMk1:
                    damage = WeaponParametrsManager.DEFAULT_DAMAGE;
                    cooldown = WeaponParametrsManager.DEFAULT_RELOAD_COOLDOWN;
                    break;
            }

            var weaponModel = new WeaponModel(damage, cooldown);

            return weaponModel;
        }
    }
}
