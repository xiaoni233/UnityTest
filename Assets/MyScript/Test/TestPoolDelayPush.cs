using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoolDelayPush : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Push", 1);
    }
    void Push()
    {
        MyPoolMgr.GetMyInstance().PushObj(this.gameObject.name, this.gameObject);
    }
}
