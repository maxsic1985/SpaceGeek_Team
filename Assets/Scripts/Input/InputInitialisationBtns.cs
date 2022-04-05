using UnityEngine;

namespace GeekSpace.INPUT
{
    internal class InputInitialisationBtns : IInitialisation, IInputInitialisation
    {

        readonly private IUserInputFire _pcInputFire;

        KeyCode _left;
        KeyCode _right;
        KeyCode _up;
        KeyCode _down;
        KeyCode _fire;


        public InputInitialisationBtns((KeyCode left, KeyCode right,KeyCode up, KeyCode down, KeyCode fire) GetKey)
        {
            _left = GetKey.left;
            _right = GetKey.right;
            _up = GetKey.up;
            _down = GetKey.down;
            _fire = GetKey.fire;
        }

        public void Initialization()
        {

        }

        public bool GetUp()
        {
            return (Input.GetKey(_up)) ? true : false;
        }

        public bool GetDown()
        {
            return (Input.GetKey(_down)) ? true : false;
        }

        public bool GetLeft()
        {
            return (Input.GetKey(_left)) ? true : false;
        }

        public bool GetRight()
        {
            return (Input.GetKey(_right)) ? true : false;
        }

        public bool GetFire()
        {
            return (Input.GetKey(_fire)) ? true : false;
        }
    }
}