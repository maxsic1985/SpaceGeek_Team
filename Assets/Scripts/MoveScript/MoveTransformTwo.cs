using UnityEngine;
using GeekSpace.INPUT;
using GeekSpace.MODEL;
namespace GeekSpace.MOVE
{
    internal class MoveTransformTwo : IMoveble
    {
        readonly private PlayerModel _playerModelTwo;
        readonly private IUserInputProxy _horizontalTwoInputProxy;
        readonly private IUserInputProxy _verticalTwoInputProxy;
        private float _horizontalTwo;
        private float _verticalTwo;

        public MoveTransformTwo(PlayerModel playerModelTwo, (IUserInputProxy inputHorizontalTwo, IUserInputProxy inputVerticalTwo) input)
        {
            _playerModelTwo = playerModelTwo;
            _horizontalTwoInputProxy = input.inputHorizontalTwo;
            _verticalTwoInputProxy = input.inputVerticalTwo;
            _horizontalTwoInputProxy.AxisOnChange += HorizontalTwoOnAxisOnChange;
            _verticalTwoInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        void VerticalOnAxisOnChange(float value)
        {
            _verticalTwo = value;
        }

        void HorizontalTwoOnAxisOnChange(float value)
        {
            _horizontalTwo = value;
        }

        public void Move(Transform transform)
        {
            var shipSpeed = _playerModelTwo.Speed;
            var movement = new Vector3(_horizontalTwo, _verticalTwo, 0);
            transform.position = (transform.position + movement * shipSpeed * Time.deltaTime);
        }
    }
}