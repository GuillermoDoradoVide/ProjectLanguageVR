using UnityEngine;
using System.Collections;

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
            return instance;
        }
    }

    protected void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
        if (instance != null && instance != this)
        {
            Debug.LogError(name + ":error: already initialized", this);
            Destroy(this.gameObject);
        }
        instance = (T)this;
        doAtAwake();
    }

    protected virtual void doAtAwake()
    {
        Debug.Log("Virtual doAtAwake [Singleton:" + name + "]");
    }
}