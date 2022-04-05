
using UnityEngine;

namespace GeekSpace
{
    [CreateAssetMenu(fileName ="GameData",menuName ="Game" )]
    internal class GameData : ScriptableObject
    {
        [SerializeField]internal GameType _GameType;

        [SerializeField] internal KeyCode LEFT = KeyCode.LeftArrow;
        [SerializeField] internal KeyCode RIGHT = KeyCode.RightArrow;
        [SerializeField] internal KeyCode UP = KeyCode.UpArrow;
        [SerializeField] internal KeyCode DOWN = KeyCode.DownArrow;
        [SerializeField] internal KeyCode FIRE = KeyCode.Space;
        [SerializeField] internal KeyCode AltLEFT = KeyCode.A;
        [SerializeField] internal KeyCode AltRIGHT = KeyCode.D;
        [SerializeField] internal KeyCode AltUP = KeyCode.W;
        [SerializeField] internal KeyCode AltDOWN = KeyCode.S;
        [SerializeField] internal KeyCode AltFIRE = KeyCode.E;

        [SerializeField] internal AudioClip PlayerFireClip;
        [SerializeField] internal AudioClip AsteroidBurst;
        [SerializeField] internal AudioClip ShipBurst;

    }
}
