using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyInputMgr.GetMyInstance().StartOrEndCheck(true);
        MyEventCenter.GetMyInstance().AddEventListener<KeyCode>("某键按下", CheckInputDown);
    }

  private void CheckInputDown(KeyCode key)
    {
        KeyCode code = (KeyCode)key;
        switch(code)
        {
            case KeyCode.W:
                Debug.Log("前进");
                break;
            case KeyCode.A:
                Debug.Log("左转");
                break;
            case KeyCode.S:
                Debug.Log("后退");
                break;
            case KeyCode.D:
                Debug.Log("右进");
                break;
        }
    }
}
