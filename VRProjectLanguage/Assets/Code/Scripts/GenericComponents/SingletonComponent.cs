﻿using UnityEngine;
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
                Debug.Log("[Singleton] Using instance already created: " + instance.gameObject.name);
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