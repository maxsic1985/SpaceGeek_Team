using System;
using UnityEngine;
using GeekSpace.MODEL;
namespace GeekSpace.ACTION
{
    public sealed class GameEventSystem : MonoBehaviour
    {
        public static GameEventSystem current;

        void Awake()
        {
            current = this;
        }

        #region WinLoose
        public event Action onWin;
        public void Win()
        {
            if (onWin != null)
            {
                onWin();
            }
        }
        public event Action onLoose;
        public void Loose()
        {
            if (onLoose != null)
            {
                onLoose();
            }
        }
        #endregion

        #region ActionEvents
        public event Action<IModel> onTakeDamage;
        public void TakeDamage(IModel model)
        {
            if (onTakeDamage != null)
            {
                onTakeDamage(model);
            }
        }

        public event Action onDestroyNearby;
        public void DestroyNearby()
        {
            if (onDestroyNearby != null)
            {
                onDestroyNearby();
            }
        }
        #endregion

        #region Changes
        public event Action onScoreUpdate;
        public void ScoreUpdate()
        {
            if (onScoreUpdate != null)
            {
                onScoreUpdate();
            }
        }
        public event Action onSpeedChange;
        public void SpeedChange()
        {
            if (onSpeedChange != null)
            {
                onSpeedChange();
            }
        }
        #endregion

        #region WorldEvents
        public event Action<IDynamicModel> onGoingBeyondScreen;
        public void GoingBeyondScreen(IDynamicModel model)
        {
            if (onGoingBeyondScreen != null)
            {
                onGoingBeyondScreen(model);
            }
        }
        #endregion
    }
}

