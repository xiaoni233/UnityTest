using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestMusic : MonoBehaviour
{
    GUIStyle s;
    GUIStyle s1;
    float v = 1;

    AudioSource source;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 500, 500), "��������")) 
        MyMusicMgr.GetMyInstance().PlayBkMusic("Black");

        if (GUI.Button(new Rect(0, 500, 500, 500), "��ͣ����")) 
        MyMusicMgr.GetMyInstance().PauseBKMusic();

        if (GUI.Button(new Rect(0, 1000, 500, 500), "ֹͣ����")) 
        MyMusicMgr.GetMyInstance().StopBkMusic();

        v += Time.deltaTime / 100;
        MyMusicMgr.GetMyInstance().ChangeBKValue(v);
        if (GUI.Button(new Rect(0, 1500, 500, 500), "������Ч"))
            MyMusicMgr.GetMyInstance().PlaySound("AirSlamLanding", false, (s) =>
           {
               source = s;
           });
        if(GUI.Button(new Rect(0, 2000, 500, 500),"ֹͣ��Ч"))
        {
            MyMusicMgr.GetMyInstance().StopSound(source);
            source = null;
        }
    }
}
