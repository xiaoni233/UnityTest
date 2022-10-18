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
    //���ز����ûص�������ע�������
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
        MyEventCenter.GetMyInstance().AddEventListener<float>("������", (objInfo) =>
        {
            Debug.Log("����Ϊ��" + objInfo);
        });
    }
}
