using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public interface IMyEventInfo
{

}
public class MyEventInfo<T>:IMyEventInfo
{
    public UnityAction<T> actions;
    public MyEventInfo(UnityAction<T> action)
    {
        actions += action;
    }
}
public class MyEventInfo : IMyEventInfo
{
    public UnityAction actions;
    public MyEventInfo(UnityAction action)
    {
        actions += action;
    }
}



public class MyEventCenter : MyBaseManager<MyEventCenter>
{
    private Dictionary<string, IMyEventInfo> evenDic = new Dictionary<string, IMyEventInfo>();

    public void AddEventListener<T>(string name,UnityAction<T> action)
    {
        if(evenDic.ContainsKey(name))
        {
            (evenDic[name] as MyEventInfo<T>).actions += action;
        }
        else
        {
            evenDic.Add(name, new MyEventInfo<T>(action));
        }
    }
    public void EvenTrigger<T>(string name,T info)
    {
        if(evenDic.ContainsKey(name))
        {
            if((evenDic[name] as MyEventInfo<T>).actions!=null)
            {
                (evenDic[name] as MyEventInfo<T>).actions.Invoke(info);
            }
        }
    }
    public void RemoveEventListener<T>(string name,UnityAction<T> action)
    {
        if(evenDic.ContainsKey(name))
        {
            (evenDic[name] as MyEventInfo<T>).actions -= action;
        }
    }

    public void Clear()
    {
        evenDic.Clear();
    }

    public void AddEventListener(string name,UnityAction action)
    {
        if (evenDic.ContainsKey(name))
        {
            (evenDic[name] as MyEventInfo).actions += action;
        }
        else
        {
            evenDic.Add(name, new MyEventInfo(action));
        }
    }

    public void RemoveEventListener(string name, UnityAction action)
    {
        if (evenDic.ContainsKey(name))
        {
            (evenDic[name] as MyEventInfo).actions -= action;
        }
    }

    public void EvenTrigger(string name)
    {
        if (evenDic.ContainsKey(name))
        {
            if ((evenDic[name] as MyEventInfo).actions != null)
            {
                (evenDic[name] as MyEventInfo).actions.Invoke();
            }
        }
    }
}
