using UnityEngine;
using System.Collections;

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

    protected void Awake()
    {
        doAtAwake();
    }
    /// <summary>
    /// Customizable Templated method that will run on awake.
    /// </summary>
    protected virtual void doAtAwake()
    {
        Debug.Log("Virtual doAtAwake [Singleton:" + name + "]");
    }
}