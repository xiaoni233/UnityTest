using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBaseManager<T> where T:new()
{
    private static T myInstance;
   
    public static T GetMyInstance()
    {
        if(myInstance==null)
        {
            myInstance = new T();
        }
        return myInstance;
    }

}
