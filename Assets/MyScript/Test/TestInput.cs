using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyInputMgr.GetMyInstance().StartOrEndCheck(true);
        MyEventCenter.GetMyInstance().AddEventListener<KeyCode>("ĳ������", CheckInputDown);
    }

  private void CheckInputDown(KeyCode key)
    {
        KeyCode code = (KeyCode)key;
        switch(code)
        {
            case KeyCode.W:
                Debug.Log("ǰ��");
                break;
            case KeyCode.A:
                Debug.Log("��ת");
                break;
            case KeyCode.S:
                Debug.Log("����");
                break;
            case KeyCode.D:
                Debug.Log("�ҽ�");
                break;
        }
    }
}
