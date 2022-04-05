using UnityEngine;
public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        var cnt = FindObjectsOfType<DontDestroy>().Length;
        if (cnt > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
