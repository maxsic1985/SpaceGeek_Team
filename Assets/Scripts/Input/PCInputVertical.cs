using System;
using UnityEngine;

namespace GeekSpace.INPUT
{
    public sealed class PCInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate (float f) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(InputManager.VERTICAL));
        }
    }
}