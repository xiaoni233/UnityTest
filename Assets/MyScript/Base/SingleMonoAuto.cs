using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMonoAuto<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T myInstance;
    public static T MyGetInstance()
    {
        if(myInstance ==null)
        {
            GameObject obj = new GameObject();
            obj.name = typeof(T).ToString();
            DontDestroyOnLoad(obj);
            myInstance = obj.AddComponent<T>();
        }
        return myInstance;
    }
}
