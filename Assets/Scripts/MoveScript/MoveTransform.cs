using UnityEngine;
using GeekSpace.INPUT;
using GeekSpace.MODEL;
namespace GeekSpace.MOVE
{
    internal class MoveTransform : IMoveble
    {
        readonly private PlayerModel _playerModel;
        readonly private IUserInputProxy _horizontalInputProxy;
        readonly private IUserInputProxy _verticalInputProxy;
        private readonly IInputInitialisation _input;
        private float _horizontal;
        private float _vertical;

        public MoveTransform(PlayerModel playerModel,IInputInitialisation input)
        {
            _playerModel = playerModel;
            _input = input;

            if (_input is InputInitializatioAxis initializatioAxis)
            {
                _horizontalInputProxy = initializatioAxis.GetInput().inputHorizontal;
                _verticalInputProxy = initializatioAxis.GetInput().inputVertical;
                _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
                _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            }

        }

        private void GetInputFromBtn()
        {
            if (_input is InputInitialisationBtns initialisationBtns)
            {
                if (initialisationBtns.GetUp()) _vertical = 1;
                else if (initialisationBtns.GetDown()) _vertical = -1;
                else _vertical = 0;
                if (initialisationBtns.GetLeft()) _horizontal = -1;
                else if (initialisationBtns.GetRight()) _horizontal = 1;
                else _horizontal = 0;
            }
        }



        void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Move(Transform transform)
        {
            GetInputFromBtn();
            var shipSpeed = _playerModel.Speed;
            var movement = new Vector3(_horizontal, _vertical, 0);
            transform.position = (transform.position + movement * shipSpeed * Time.deltaTime);
        }
    }
}
