using UnityEngine;
using GeekSpace.ACTION;
namespace GeekSpace
{
    internal class CheatGUI : MonoBehaviour
    {
        void OnGUI()
        {
            GUI.Box(new Rect(10, 10, 200, 210), "Cheats");
            if (GUI.Button(new Rect(20, 40, 180, 30), "Destroy nearby"))
            {
                GameEventSystem.current.DestroyNearby();
            }
                
        }

    }
}
