using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventMonster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dead();
    }

    void Dead()
    {
        Debug.Log("¹ÖÎïËÀÍö");
        MyEventCenter.GetMyInstance().EvenTrigger<TestEventMonster>("MonsterDead",this);
    }
 }
