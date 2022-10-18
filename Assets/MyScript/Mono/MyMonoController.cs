using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MyMonoController : MonoBehaviour
{
    private event UnityAction updateEvent;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (updateEvent != null)
            updateEvent();
    }
    public void AddUpdateListener(UnityAction fun)
    {
        updateEvent += fun;
    }
    public void RemoveUpdateListener(UnityAction fun)
    {
        updateEvent -= fun;
    }
}
