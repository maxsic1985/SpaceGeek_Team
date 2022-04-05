using System;
using UnityEngine;

namespace GeekSpace.INPUT
{
    internal class PCInputFire : IUserInputFire
    {
        public event Action<float> AxisOnChange = delegate (float f) { };

        public void GetFire()
        {
            AxisOnChange.Invoke(Input.GetAxis(InputManager.FIRE1));
        }
    }
}