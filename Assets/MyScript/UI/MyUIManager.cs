using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public enum My_E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System,
}

public class MyUIManager : MyBaseManager<MyUIManager>
{
    public Dictionary<string, MyBasePanel> panelDic = new Dictionary<string, MyBasePanel>();
    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    public RectTransform canvas;

    public MyUIManager()
    {
        GameObject obj = MyResMgr.GetMyInstance().Load<GameObject>("UI/Canvas");
        canvas = obj.transform as RectTransform;
        GameObject.DontDestroyOnLoad(obj);

        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        obj = MyResMgr.GetMyInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }

    public void ShowPanel<T>(string panelName,My_E_UI_Layer layer=My_E_UI_Layer.Mid,UnityAction<T> callBack=null)where T:MyBasePanel
    {
        if(panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            if (callBack != null)
                callBack(panelDic[panelName] as T);
            return;
        }
        MyResMgr.GetMyInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
           {
               Transform father = bot;
               switch (layer)
               {
                   case My_E_UI_Layer.Mid:
                       father = mid;
                       break;
                   case My_E_UI_Layer.Top:
                       father = top;
                       break;
                   case My_E_UI_Layer.System:
                       father = system;
                       break;
               }

               obj.transform.SetParent(father);
               obj.transform.localPosition = Vector3.zero;
               obj.transform.localScale = Vector3.one;

               (obj.transform as RectTransform).offsetMax = Vector2.zero;
               (obj.transform as RectTransform).offsetMin = Vector2.zero;

               T panel = obj.GetComponent<T>();
               if (callBack != null)
                   callBack(panel);

               panel.ShowMe();
               panelDic.Add(panelName, panel);
           });
    }

    public void HidePanel(string panelName)
    {
        if(panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HideMe();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }

    public T GetPanel<T>(string name)where T:MyBasePanel
    {
        if (panelDic.ContainsKey(name))
            return panelDic[name] as T;
        return null;
    }

    public Transform GetLayerFather(My_E_UI_Layer layer)
    {
        switch(layer)
        {
            case My_E_UI_Layer.Bot:
                return this.bot;
            case My_E_UI_Layer.Mid:
                return this.mid;
            case My_E_UI_Layer.Top:
                return this.top;
            case My_E_UI_Layer.System:
                return this.system;
        }
        return null;
    }

    public static void AddCustomEventListener(UIBehaviour control,EventTriggerType type,UnityAction<BaseEventData> callBack)
    {
        EventTrigger trigger = control.GetComponent<EventTrigger>();
        if(trigger==null)
        {
            trigger = control.gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(callBack);

        trigger.triggers.Add(entry);
    }
}
