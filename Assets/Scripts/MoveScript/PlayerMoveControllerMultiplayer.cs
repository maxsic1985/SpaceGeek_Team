namespace GeekSpace.MOVE
{
    internal class PlayerMoveControllerMultiplayer : IExecute
    {
        Player _player;
        PlayerTwo _playerTwo;

        internal PlayerMoveControllerMultiplayer(Player player, PlayerTwo playerTwo)
        {
            _player = player;
            _playerTwo = playerTwo;
        }

        public void Execute(float deltaTime)
        {
            _player.Move(deltaTime);
            _playerTwo.Move(deltaTime);
        }
    }
}