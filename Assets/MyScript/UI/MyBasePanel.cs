using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MyBasePanel : MonoBehaviour
{
    private Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();

     protected virtual void Awake()
    {
        FindChildrenControl<Button>();
        FindChildrenControl<Image>();
        FindChildrenControl<Text>();
        FindChildrenControl<Toggle>();
        FindChildrenControl<Slider>();
        FindChildrenControl<ScrollRect>();
        FindChildrenControl<InputField>();
    }

    public virtual void ShowMe()
    {

    }
    public virtual void HideMe()
    {

    }

    protected T GetControl<T>(string controlName)where T:UIBehaviour
    {
        if(controlDic.ContainsKey(controlName))
        {
            for(int i=0;i<controlDic[controlName].Count;++i)
            {
                if(controlDic[controlName][i] is T)
                {
                    return controlDic[controlName][i] as T;
                }
            }
        }
        return null;
    }

    private void FindChildrenControl<T>()where T:UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
       
        for(int i=0;i<controls.Length;++i)
        {
            string objName = controls[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
                controlDic[objName].Add(controls[i]);
            else
                controlDic.Add(objName, new List<UIBehaviour>() { controls[i] });
            //����ǰ����ؼ�
            if(controls[i] is Button)
            {
                (controls[i] as Button).onClick.AddListener(() =>
                {
                    OnClick(objName);
                });
            }
            else if(controls[i] is Toggle)
            {
                (controls[i] as Toggle).onValueChanged.AddListener((value) =>
                {
                    OnValueChanged(objName, value);
                });
            }
        }
    }

    protected virtual void OnClick(string btnName)
    {

    }
    protected virtual void OnValueChanged(string toggleName,bool value)
    {

    }
}
