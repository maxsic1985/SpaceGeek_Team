using UnityEngine;
using GeekSpace.POOL;
namespace GeekSpace.MODEL
{
    internal sealed class BulletModel :  IDynamicModel
    {
        private Vector3 _position;
        private GameObject _bulletObject;
        private IPool _pool;
        private float _speed;

        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public GameObject Object
        {
            get { return _bulletObject; }
            set { _bulletObject = value; }
        }
        public IPool Pool
        {
            get { return _pool; }
            set { _pool = value; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public BulletModel(IPool pool, Vector3 position,float speed)
        {
            _pool = pool;         
            _position = position;
            _speed = speed;
        }
    }
}

