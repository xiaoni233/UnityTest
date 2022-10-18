using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Internal;
public class MyMonoMgr : MyBaseManager<MyMonoMgr>
{
    private MyMonoController controller;
    public MyMonoMgr()
    {
        GameObject obj = new GameObject("MyMonoController");
        controller = obj.AddComponent<MyMonoController>();
    }
    public void AddUpdateListener(UnityAction fun)
    {
        controller.AddUpdateListener(fun);
    }
    public void RemoveUpdateListener(UnityAction fun)
    {
        controller.RemoveUpdateListener(fun);
    }
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }
    public void StopCoroutine(IEnumerator routine)
    {
        controller.StopCoroutine(routine);
    }
}
