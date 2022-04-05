namespace GeekSpace.MOVE
{
    internal class PlayerMoveController : IExecute 
    {
        Player _player;

        internal PlayerMoveController(Player player)
        {
            _player = player;
        }

        public void Execute(float deltaTime)
        {
            _player.Move(deltaTime);
        }
    }
}
