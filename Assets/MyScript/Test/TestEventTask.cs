using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        MyEventCenter.GetMyInstance().AddEventListener<TestEventMonster>("MonsterDead", TaskWaitMonsterDeadDo);
        MyEventCenter.GetMyInstance().AddEventListener<TestEventMonster>("MonsterDead", Win);
    }

   public void TaskWaitMonsterDeadDo(TestEventMonster info)
   {
        Debug.Log("���������������,��������Ϊ:"+info);
   }

    private void OnDestroy()
    {
        MyEventCenter.GetMyInstance().RemoveEventListener<TestEventMonster>("MonsterDead", TaskWaitMonsterDeadDo);
    }
    public void Win(TestEventMonster info)
    {
        Debug.Log("win");
    }
}
