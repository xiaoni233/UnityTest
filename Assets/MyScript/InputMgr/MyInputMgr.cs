using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInputMgr : MyBaseManager<MyInputMgr>
{
    private bool isStart = false;
    public MyInputMgr()
    {
        MyMonoMgr.GetMyInstance().AddUpdateListener(MyUpdate);
    }
    public void StartOrEndCheck(bool isOpen)
    {
        isStart = isOpen;
    }
    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
            MyEventCenter.GetMyInstance().EvenTrigger("ĳ������", key);
        if (Input.GetKeyUp(key))
            MyEventCenter.GetMyInstance().EvenTrigger("ĳ��̧��", key);
    }
    private void MyUpdate()
    {
        if (!isStart)
            return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.D);
    }
}
