using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
      {
            GameObject obj = MyResMgr.GetMyInstance().Load<GameObject>("Test/Cube");
            obj.transform.localScale = Vector3.one * 2;
      }
        if (Input.GetMouseButtonDown(1))
        {
            //MyResMgr.GetMyInstance().LoadAsync<GameObject>("Test/Cube", DoSomething);
            MyResMgr.GetMyInstance().LoadAsync<GameObject>("Test/Cube", (obj) =>
             {
                 obj.transform.localScale = Vector3.one * 2;
             });
        }
    }
    private void DoSomething(GameObject obj)
    {
        obj.transform.localScale = Vector3.one * 2;
    }
}
