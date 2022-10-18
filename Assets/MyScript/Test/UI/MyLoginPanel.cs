using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class MyLoginPanel : MyBasePanel
{
    //找到所有控件
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
             Debug.Log("进入btnStart");
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
    //覆盖父类Onclick，接受找到控件后，同时注册控件，这里是接受注册控件的触发函数对象信息
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
