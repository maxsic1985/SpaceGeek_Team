using UnityEngine;
using GeekSpace.POOL;
namespace GeekSpace.MODEL
{
    internal sealed class PlayerModel :  IDynamicModel
    {
        readonly private string _pathToPrefab;
        readonly private WeaponType _weaponType;
        private WeaponModel _weaponModel;
        private Vector3 _position;
        private float _angle;
        private GameObject _playerObject;
        private IPool _pool;
        private int _healthPoitns;
        readonly private float _speed;

        public WeaponType WeaponType
        {
            get { return _weaponType; }
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
            get { return _playerObject; }
            set { _playerObject = value; }
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
        public float Speed
        {
            get { return _speed; }
        }

        public float Angle
        {
            get { return _angle; }
        }

        public PlayerModel(string pathToPrefab, WeaponType weaponType, WeaponModel weaponModel, Vector3 position,float angle, int healthPoitns, float speed)
        {
            _pathToPrefab = pathToPrefab;
            _weaponType = weaponType;
            _weaponModel = weaponModel;
            _position = position;
            _healthPoitns = healthPoitns;
            _speed = speed;
            _angle = angle;
        }
    }
}

