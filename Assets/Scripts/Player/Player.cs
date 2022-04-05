using UnityEngine;
using GeekSpace.MODEL;
using GeekSpace.CONSTANT;
using GeekSpace.MOVE;
using GeekSpace.PROVIDER;

namespace GeekSpace
{
    internal class Player
    {
        private readonly IMoveble _playerMove;
        private readonly PlayerModel _playerModel;
        internal PlayerProviderBeh PlayerProvider { get; }

        internal Player (IMoveble playerMove, PlayerModel playerModel)
        {
            _playerMove = playerMove;
            _playerModel = playerModel;
            var player = GameObject.Instantiate(Resources.Load<PlayerProviderBeh>(PathsManager.PLAYER_PREFAB));
            PlayerProvider = player.GetComponent<PlayerProviderBeh>();
            PlayerProvider.PlayerModel = _playerModel;
            player.transform.position = _playerModel.Position;
            player.transform.rotation = Quaternion.Euler(0,0,_playerModel.Angle);

        }

        internal void Move(float timeDelta)
        {
            if (PlayerProvider == null) return;
            _playerMove.Move(PlayerProvider.transform);
        }
    }
}

