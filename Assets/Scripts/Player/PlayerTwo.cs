using UnityEngine;
using GeekSpace.MODEL;
using GeekSpace.CONSTANT;
using GeekSpace.MOVE;
using GeekSpace.PROVIDER;
namespace GeekSpace
{
    internal class PlayerTwo
    {
        private readonly IMoveble _playerMoveTwo;
        private readonly PlayerModel _playerModelTwo;
        internal PlayerProviderBeh PlayerProvider { get; }

        internal PlayerTwo(IMoveble playerMoveTwo, PlayerModel playerModelTwo)
        {
            _playerMoveTwo = playerMoveTwo;
            _playerModelTwo = playerModelTwo;
            var player = GameObject.Instantiate(Resources.Load<PlayerProviderBeh>(PathsManager.PLAYER_PREFAB_TWO));
            PlayerProvider = player.GetComponent<PlayerProviderBeh>();
            PlayerProvider.PlayerModel = _playerModelTwo;
            player.transform.position = _playerModelTwo.Position;
        }

        internal void Move(float timeDelta)
        {
            _playerMoveTwo.Move(PlayerProvider.transform);
        }
    }
}