using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIMgr : MonoBehaviour
{
    // Start is called before the first frame update
    //展示面板
    void Start()
    {
        MyUIManager.GetMyInstance().ShowPanel<MyLoginPanel>("LoginPanel", My_E_UI_Layer.Mid,ShowPanelOver);
    }
    //加载面板后的回调函数
    private void ShowPanelOver(MyLoginPanel panel)
    {
        //初始化面板数据
        panel.InitInfo();
        panel.gameObject.SetActive(true);
    }
}
