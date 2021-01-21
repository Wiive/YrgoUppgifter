using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingelton<T> : MonoBehaviour where T : MonoSingelton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError(typeof(T).ToString() + " is Null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = (T)this;

        Init();
    }

    public virtual void Init() 
    {
        //Optional awake fuctions for different singeltons.
    }
}
