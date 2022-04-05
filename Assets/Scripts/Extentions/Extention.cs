using UnityEngine;
namespace GeekSpace.EXTENSHION
{
    public static class Extention
    {
        public static int StirngLength(string inputString)
        {
            int output = 0;
            output = inputString.Length;
            return output;
        }
        #region Vector
        public static Vector3 MultiplyX(this Vector3 v, float val)
        {
            v = new Vector3((val * v.x), v.y, v.z);
            return v;
        }
        public static Vector3 MultiplyY(this Vector3 v, float val)
        {
            v = new Vector3(v.x, (val * v.y), v.z);
            return v;
        }
        public static Vector3 MultiplyZ(this Vector3 v, float val)
        {
            v = new Vector3(v.x, v.y, (val * v.z));
            return v;
        }
        #endregion
        #region Components
        public static T GetOrAddComponent<T>(this GameObject child) where T : Component
        {
            T result = child.GetComponent<T>();
            if (result == null)
            {
                result = child.AddComponent<T>();
            }
            return result;
        }

        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }
        public static GameObject AddRigidBody2D(this GameObject gameObject, float mass)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return gameObject;
        }
        public static GameObject AddRigidBody(this GameObject gameObject, float mass)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            return gameObject;
        }
        public static GameObject AddBoxCollider2D(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<BoxCollider2D>();
            return gameObject;
        }
        public static GameObject AddBoxCollider(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<BoxCollider>();
            return gameObject;
        }
        public static GameObject AddCircleCollider2D(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<CircleCollider2D>();
            return gameObject;
        }
        public static GameObject AddSphereCollider(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<SphereCollider>();
            return gameObject;
        }
        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }
        public static GameObject AddMesh(this GameObject gameObject, Material material)
        {
            var component = gameObject.GetOrAddComponent<MeshRenderer>();
            component.material = material;
            return gameObject;
        }
        #endregion
        #region Vector according Camera
        public static Vector3 GetCentrAccordingCamera(this Camera camera)
        {
            var centrPosition = new Vector3(camera.transform.position.x, camera.transform.position.y, 0);
            return centrPosition;
        }
        public static Vector3 GetRandomVectorAccordingCamera(this Camera camera, float offsetX, float offsetY)
        {
            var weight = ((camera.orthographicSize * 2) * camera.aspect) / 2;
            var height = camera.orthographicSize;
            var randomX = Random.Range(-1 * weight + offsetX, weight - offsetX);
            var vector = new Vector2(randomX, Mathf.Abs(height) - offsetY);
            return vector;
        }
        public static Vector2 GetLeftSideVector2AccordingCamera(this Camera camera, float offset)
        {
            var vector_left = new Vector2((camera.transform.localPosition.z + offset), camera.transform.localPosition.y);
            return vector_left;
        }

        public static float GetLeftSideValueAccordingCamera(this Camera camera, float offset)
        {
            var left = (camera.transform.localPosition.z + offset);
            return left;
        }
        public static Vector2 GetRightSideVector2AccordingCamera(this Camera camera, float offset)
        {
            var right = (camera.transform.localPosition.z + offset) * -1;
            var vector_right = new Vector2(right, camera.transform.localPosition.y);
            return vector_right;
        }

        public static float GetRightSideValueAccordingCamera(this Camera camera, float offset)
        {
            var right = (camera.transform.localPosition.z + offset) * -1;
            return right;
        }

        public static float GetUpSideValueAccordingCamera(this Camera camera, float offset)
        {
            var up = (((camera.transform.localPosition.z / 2) + offset) * -1);
            return up;
        }

        public static float GetDownSideValueAccordingCamera(this Camera camera, float offset)
        {
            var down = ((camera.transform.localPosition.z / 2) + offset);
            return down;
        }
        #endregion
    }
}