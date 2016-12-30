using UnityEngine;
using System.Collections;
[AddComponentMenu("Generic/ScriptableObjectSingleton")]
public abstract class ScriptableObjectSingletonComponent<T> : ScriptableObject where T : ScriptableObjectSingletonComponent<T>
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
            if (!instance)
            {
                instance = FindObjectOfType<T>();
            }
            if (!instance)
            {
                instance = CreateInstance<T>();
                Debug.Log("[Singleton] An instance of " + typeof(T) + " is needed , so '" + instance + "' was created as an scriptableSingleton.");
            }
            else
            {
                Debug.Log("[Singleton] Using instance already created: " + instance.name);
            }
            return instance;
        }
    }
}