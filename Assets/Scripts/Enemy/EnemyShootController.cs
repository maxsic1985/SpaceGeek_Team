using GeekSpace.EXTENSHION;
using UnityEngine;
using GeekSpace.POOL;
namespace GeekSpace.ENEMY
{
    internal class EnemyShootController : ShootControllerWithAutoShoot
    {
        internal EnemyShootController(TimerSystem timerSystem, IPool enemyPool, Transform startPosition, GameObject player, string enemyLayerMask,AudioClip shootAudioClip) : base(timerSystem, enemyPool, startPosition, player, enemyLayerMask,shootAudioClip)
        {

        }
        public override void GetShoot()
        {
            if (_player.activeSelf == false) return;
            _hit = Physics2D.Raycast(_player.transform.position, -_player.transform.up, 100.0f, _enemyLayerMask);
            if (_timerSystem.CheckEvent() && _hit)
            {
                Extention.GetOrAddComponent<AudioSource>(_camera.gameObject).PlayOneShot(_shootAudioClip);
                var startpos = new Vector2(_startPosition.transform.position.x, (_startPosition.transform.position.y - 1));
                var a = _enemyPool.Pop(startpos, _startPosition.rotation);
                a.GetComponent<Rigidbody2D>().AddForce((-_startPosition.transform.up * 3));
                return;
            }
        }
    }
}