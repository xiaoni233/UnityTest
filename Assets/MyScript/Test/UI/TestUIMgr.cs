using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIMgr : MonoBehaviour
{
    // Start is called before the first frame update
    //չʾ���
    void Start()
    {
        MyUIManager.GetMyInstance().ShowPanel<MyLoginPanel>("LoginPanel", My_E_UI_Layer.Mid,ShowPanelOver);
    }
    //��������Ļص�����
    private void ShowPanelOver(MyLoginPanel panel)
    {
        //��ʼ���������
        panel.InitInfo();
        panel.gameObject.SetActive(true);
    }
}
