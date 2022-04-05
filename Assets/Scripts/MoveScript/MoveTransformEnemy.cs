using GeekSpace.MODEL;
using UnityEngine;

namespace GeekSpace.MOVE
{
    internal class MoveTransformEnemy : IMoveble
    {
        private EnemyModel _enemyModel;
        private GameObject _player;
        public MoveTransformEnemy(EnemyModel enemyModel, GameObject player)
        {
            _enemyModel = enemyModel;
            _player = player;
        }

        public void Move(Transform transform)
        {
            if (_player == null) return;
            var speed = _enemyModel.Speed * Time.deltaTime;
            var pos = Vector2.MoveTowards(transform.position, _player.transform.position, speed);
            transform.position = new Vector2(pos.x, transform.position.y);
        }
    }
}