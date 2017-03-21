using UnityEngine;
using System.Collections;
[AddComponentMenu("Generic/Singleton")]
public abstract class SingletonComponent<T> : MonoBehaviour where T : SingletonComponent<T>
{
    protected static T instance = null;
    /// <summary>
    /// Returns the instance of this singleton.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType<T>();
            }
            if (!instance)
            {
                GameObject singleton = new GameObject();
                instance = singleton.AddComponent<T>();
                singleton.name = "(singleton)" + typeof(T).ToString();
                DontDestroyOnLoad(singleton);
                Debug.Log("[Singleton] An instance of " + typeof(T) + " is needed in the scene, so '" + singleton + "' was created with DontDestroyOnLoad.");
            }
            else
            {
//                Debug.Log("[Singleton] Using instance already created: " + instance.gameObject.name);
            }
            return instance;
        }
    }
}