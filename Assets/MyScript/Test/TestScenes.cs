using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScenes : MonoBehaviour
{
    string nameStr = "TestScene";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        printProgress();
        LoadGameAsyn(nameStr);
    }
    //加载并调用回调函数和注册进度条
    void LoadGameAsyn(string name)
    {
        MyScenesMgr.GetInstance().LoadSceneAsyn(name, printOk);
    }
    void printOk()
    {
        Debug.Log("loadGame OK");
    }
    
    void printProgress()
    {
        float progress;
        MyEventCenter.GetMyInstance().AddEventListener<float>("进度条", (objInfo) =>
        {
            Debug.Log("进度为：" + objInfo);
        });
    }
}
