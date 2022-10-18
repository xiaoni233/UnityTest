using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TestMono 
{
    public TestMono()
    {
        MyMonoMgr.GetMyInstance().AddUpdateListener(this.Update);
        MyMonoMgr.GetMyInstance().StartCoroutine(TestMyCoroutine());
    }
    void Update()
    {
        Debug.Log("Update,TestMono");
    }
    IEnumerator TestMyCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("TestMyCoroutine");
    }
}

public class TestMonoCall:MonoBehaviour
{
    private void Start()
    {
        TestMono t = new TestMono();
    }
}
