using UnityEngine;
using GeekSpace.EXTENSHION;
using GeekSpace.MODEL;
namespace GeekSpace.ACTION
{
    internal sealed class BeyondScreenActer
    {
        internal BeyondScreenActer()
        {
            GameEventSystem.current.onGoingBeyondScreen += GoingBeyondScreen;
        }
        private void GoingBeyondScreen(IDynamicModel model)
        {
            if (model == null) return;
            if (model is EnemyModel || model is BulletModel)
            {
                model.Pool.Push(model.Object);
            }
            else if (model is PlayerModel && Camera.main != null)
            {
                float weightShip = Mathf.Round(model.Object.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.rect.width / 100) + 0.2f;

                float leftBorder = Extention.GetLeftSideValueAccordingCamera(Camera.main, weightShip);
                float rightBorder = Extention.GetRightSideValueAccordingCamera(Camera.main, weightShip);
                float upBorder = Extention.GetUpSideValueAccordingCamera(Camera.main, (weightShip / 2));
                float DownBorder = Extention.GetDownSideValueAccordingCamera(Camera.main, (weightShip / 2));

                Vector3 newPosition = new Vector3();
                newPosition = model.Object.transform.position;
                if (newPosition.x <= leftBorder || newPosition.x >= rightBorder)
                {
                    newPosition.x *= -1;
                }
                if (newPosition.y <= DownBorder || newPosition.y >= upBorder)
                {
                    newPosition.y *= -1;
                }
                model.Object.transform.position = newPosition;
            }
            else
            {
                Debug.Log("Model Error");
                var asd = SceneManagment.FindObjectsOfType(typeof(GameObject));
            }

        }
        ~BeyondScreenActer()
        {
            GameEventSystem.current.onGoingBeyondScreen -= GoingBeyondScreen;
        }
    }
}

