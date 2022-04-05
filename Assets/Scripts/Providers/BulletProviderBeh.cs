using UnityEngine;
using GeekSpace.ACTION;
using GeekSpace.MODEL;
namespace GeekSpace.PROVIDER
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(MeshRenderer))]
    public class BulletProviderBeh : MonoBehaviour
    {
        private BulletModel _bulletModel;
        private Rigidbody2D _rigidbody2D;
        internal BulletModel BulletModel
        {
            get { return _bulletModel; }
            set
            {
                _bulletModel = value;
                _bulletModel.Object = gameObject;
            }
        }
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
       private void OnBecameInvisible()
        {
            ReturnToPool();
        }
        private void OnBecameVisible()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        void OnTriggerEnter2D()
        {
            ReturnToPool();
        }

        void ReturnToPool()
        {
            GameEventSystem.current.GoingBeyondScreen(_bulletModel);
        }
    }
}