using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyPoolData
{
    public GameObject fatherObj;
    public List<GameObject> poolList;
    public MyPoolData(GameObject obj,GameObject poolObj)
    {
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = poolObj.transform;
        poolList = new List<GameObject>() { };
        PushObj(obj);
    }
    public void PushObj(GameObject obj)
    {
        obj.SetActive(false);
        poolList.Add(obj);
        obj.transform.parent = fatherObj.transform;
    }
    public GameObject GetObj()
    {
        GameObject obj = null;
        obj = poolList[0];
        poolList.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.parent = null;
        return obj;
    }
}


public class MyPoolMgr : MyBaseManager<MyPoolMgr>
{
    public Dictionary<string, MyPoolData> poolDic
        = new Dictionary<string, MyPoolData>();

    private GameObject poolObj;

    public GameObject GetObj(string name,UnityAction<GameObject> callBack)
    {
        GameObject obj = null;
        if(poolDic.ContainsKey(name)&&poolDic[name].poolList.Count>0)
        {
            obj = poolDic[name].GetObj();
        }
        else
        {
            MyResMgr.GetMyInstance().LoadAsync<GameObject>(name, (o) =>
             {
                 o.name = name;
                 callBack(o);
             });
        }
        return obj;
    }

    public void PushObj(string name,GameObject obj)
    {
        if (poolObj == null)
            poolObj = new GameObject("Pool");
        
        obj.SetActive(false);
        if(poolDic.ContainsKey(name))
        {
            poolDic[name].PushObj(obj);
        }
        else
        {
            poolDic.Add(name, new MyPoolData(obj, poolObj));
        }
    }

    public void Clear()
    {
        poolDic.Clear();
        poolObj = null;
    }
    
}
