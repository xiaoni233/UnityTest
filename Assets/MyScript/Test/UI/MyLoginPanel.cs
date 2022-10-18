using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class MyLoginPanel : MyBasePanel
{
    //�ҵ����пؼ�
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        //GetControl<Button>("btnStart");
        //GetControl<Toggle>("TestToggle");
        //GetControl<Button>("btnStart").onClick.AddListener(ClickStart);
        //GetControl<Button>("btnQuit").onClick.AddListener(ClickQuit);
        MyUIManager.AddCustomEventListener(GetControl<Button>("btnStart"), EventTriggerType.PointerEnter, (data) =>
         {
             Debug.Log("����btnStart");
         });
    }

    public void ClickStart()
    {
        Debug.Log("Start");
    }
    public void ClickQuit()
    {
        Debug.Log("Quit");
    }
    public void InitInfo()
    {
        Debug.Log("InitInfo");
    }

    public override void ShowMe()
    {
        base.ShowMe();
    }
    //���Ǹ���Onclick�������ҵ��ؼ���ͬʱע��ؼ��������ǽ���ע��ؼ��Ĵ�������������Ϣ
    protected override void OnClick(string btnName)
    {
        switch(btnName)
        {
            case "btnStart":
                Debug.Log("btnStart");
                break;
            case "btnQuit":
                Debug.Log("btnQuit");
                break;
        }
    }
    protected override void OnValueChanged(string toggleName, bool value)
    {
        Debug.Log(toggleName + " " + value);
    }
}
