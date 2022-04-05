using UnityEngine;
using GeekSpace.ACTION;
using GeekSpace.MODEL;

namespace GeekSpace.PROVIDER
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PlayerProviderBeh : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private float _health;
        private float _maxHealth;
        private float _damage;
        MaterialPropertyBlock _healtBarmatBlock;
        MeshRenderer _healtBarMeshRenderer;


        private void Start()
        {
            _healtBarMeshRenderer = gameObject.transform.GetChild(1).transform.gameObject.GetComponent<MeshRenderer>();
            _healtBarmatBlock = new MaterialPropertyBlock();
            _health = _playerModel.HealthPoitns;
            _maxHealth = _health;
        }

        internal PlayerModel PlayerModel
        {
            get { return _playerModel; }
            set
            {
                _playerModel = value;
                _playerModel.Object = gameObject;
            }
        }

        void OnBecameInvisible()
        {
            GameEventSystem.current.GoingBeyondScreen(_playerModel);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.GetComponent<BulletProviderBeh>())
            {
                _damage =PlayerModel.WeaponModel.Damage;
            }
            else if (collider.GetComponent<PlayerProviderBeh>())
            {
                _damage = collider.GetComponent<PlayerProviderBeh>().PlayerModel.WeaponModel.Damage;
            }
            else if (collider.GetComponent<EnemyProviderBeh>())
            {
                if (collider.gameObject.GetComponent<EnemyProviderBeh>().EnemyModel.EnemyType is EnemyType.Asteroid)
                    _damage = EnemyParametrsManager.ASTEROID_TARAN_DAMAGE;
                if (collider.gameObject.GetComponent<EnemyProviderBeh>().EnemyModel.EnemyType is EnemyType.Ship)
                    _damage = EnemyParametrsManager.SHIP_TARAN_DAMAGE;
            }
            _health -= _damage;
            UpdateHealthBar();
            if (_health <= 0)
            {
                var sceneManagment = FindObjectOfType<Pause>();
                sceneManagment.ShowLooseMenu();
                Destroy(this.gameObject);
            }
        }
        private void UpdateHealthBar()
        {
            _healtBarMeshRenderer.GetPropertyBlock(_healtBarmatBlock);
            _healtBarmatBlock.SetFloat("_Fill", _health / _maxHealth);
            _healtBarMeshRenderer.SetPropertyBlock(_healtBarmatBlock);
        }
    }
}

