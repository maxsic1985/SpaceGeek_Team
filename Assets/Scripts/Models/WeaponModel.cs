namespace GeekSpace.MODEL
{
    internal sealed class WeaponModel : IModel
    {
        private int _damage;
        private float _cooldown;

        public int Damage
        {
            get { return _damage; }
        }
        public float Cooldown
        {
            get { return _cooldown; }
        }

        public WeaponModel(int damage, float cooldown)
        {
            _damage = damage;
            _cooldown = cooldown;
        }
    }
}

