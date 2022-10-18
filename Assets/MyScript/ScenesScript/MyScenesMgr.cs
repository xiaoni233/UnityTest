using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class MyScenesMgr : BaseManager<MyScenesMgr>
{
    public void LoadScene(string name,UnityAction fun)
    {
        SceneManager.LoadScene(name);
        fun();
    }

    public void LoadSceneAsyn(string name,UnityAction fun)
    {
        MyMonoMgr.GetMyInstance().StartCoroutine(ReallyLoadSceneAsyn(name,fun));
    }
    private IEnumerator ReallyLoadSceneAsyn(string name,UnityAction fun)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
       while(!ao.isDone)
        {
            MyEventCenter.GetMyInstance().EvenTrigger("½ø¶ÈÌõ", ao.progress);
            yield return ao.progress;
        }
        fun();
    }
}
