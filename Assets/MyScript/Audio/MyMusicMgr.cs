using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyMusicMgr :MyBaseManager<MyMusicMgr>
{
    private AudioSource bkMusic = null;
    private float bkValue = 1;
    private GameObject soundObj = null;
    private List<AudioSource> soundList = new List<AudioSource>();
    private float soundValue = 1;

    public MyMusicMgr()
    {
        MyMonoMgr.GetMyInstance().AddUpdateListener(Update);
    }
    private void Update()
    {
        for(int i=soundList.Count-1;i>=0;--i)
        {
            if(!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }
        }
    }

    public void PlayBkMusic(string name)
    {
        if(bkMusic==null)
        {
            GameObject obj = new GameObject();
            obj.name = "BkMusic";
            bkMusic = obj.AddComponent<AudioSource>();
        }
        MyResMgr.GetMyInstance().LoadAsync<AudioClip>("Music/Bk/" + name, (clip) =>
           {
               bkMusic.clip = clip;
               bkMusic.loop = true;
               bkMusic.volume = bkValue;
               bkMusic.Play();
           });
    }

    public void PauseBKMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Pause();
    }
    public void StopBkMusic()
    {
        if (bkMusic == null)
            return;
        bkMusic.Stop();
    }
    public void ChangeBKValue(float v)
    {
        bkValue = v;
        if (bkMusic == null)
            return;
        bkMusic.volume = bkValue;
    }

    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource> callBack=null)
    {
        if(soundObj==null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }
        MyResMgr.GetMyInstance().LoadAsync<AudioClip>("Music/Sound/" + name, (clip) =>
           {
               AudioSource source = soundObj.AddComponent<AudioSource>();
               source.clip = clip;
               source.loop = isLoop;
               source.volume = soundValue;
               source.Play();
               soundList.Add(source);
               if (callBack != null)
               {
                   callBack(source);
               }
           });
    }
    public void StopSound(AudioSource source)
    {
        if(soundList.Contains(source))
        {
            soundList.Remove(source);
            source.Stop();
            GameObject.Destroy(source);
        }
    }
    public void ChangeSoundValue(float value)
    {
        soundValue = value;
        for (int i = 0; i < soundList.Count; ++i)
            soundList[i].volume = value;
    }
}
