using UnityEngine;
using System.Collections;

public abstract class SingletonComponent<T> : ScriptableObject where T : SingletonComponent<T>
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
                instance = CreateInstance<T>();
                instance.hideFlags = HideFlags.HideAndDontSave;
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