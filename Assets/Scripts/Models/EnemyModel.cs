using UnityEngine;
using GeekSpace.POOL;
namespace GeekSpace.MODEL
{
    internal sealed class EnemyModel : IDynamicModel
    {
        private EnemyType _enemyType;
        private WeaponModel _weaponModel;
        private Vector3 _position;
        private GameObject _enemyObject;
        private IPool _pool;
        private int _healthPoitns;
        private int _armor;
        private int _size;
        private float _speed;
        private AudioClip _explosionClip;

        public EnemyType EnemyType
        {
            get { return _enemyType; }
        }
        public WeaponModel WeaponModel
        {
            get { return _weaponModel; }
        }
        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public GameObject Object
        {
            get { return _enemyObject; }
            set { _enemyObject = value; }
        }
        public IPool Pool
        {
            get { return _pool; }
            set { _pool = value; }
        }
        public int HealthPoitns
        {
            get { return _healthPoitns; }
            set { _healthPoitns = value; }
        }
        public int Armor
        {
            get { return _armor; }
        }
        public int Size
        {
            get { return _size; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public AudioClip ExplosionClip
        {
            get { return _explosionClip; }
        }

        public EnemyModel(IPool pool, EnemyType enemyType, WeaponModel weaponModel, Vector3 position, int healthPoitns, float speed, int armor, int size , AudioClip explosionClip)
        {
            _pool = pool;
            _enemyType = enemyType;
            _weaponModel = weaponModel;
            _position = position;
            _healthPoitns = healthPoitns * size;
            _armor = armor;
            _speed = speed;
            _size = size;
            _explosionClip = explosionClip;
        }
    }
}

