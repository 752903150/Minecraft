using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManagerSystem
{
    static Dictionary<string, IEventInfo> UnityActionDic = new Dictionary<string, IEventInfo>();//�¼�ע���ֵ�

    //����ģʽ
    private static EventManagerSystem instance = new EventManagerSystem();
    public static EventManagerSystem Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// �޲�ע�᷽��
    /// </summary>
    /// <param name="EventName"></param>
    /// <param name="Action"></param>
    public void Add(string EventName,UnityAction Action)
    {
        if(UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo).action += Action;
        }
        else//û�а�������Ҫע��
        {
            UnityActionDic.Add(EventName, new EventInfo(Action));
        }
    }

    /// <summary>
    /// �޲�ȡ��ע�ắ��
    /// </summary>
    /// <param name="EventName"></param>
    /// <param name="Action"></param>
    public void Delete(string EventName,UnityAction Action)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo).action -= Action;
        }
    }

    /// <summary>
    /// �޲δ�������
    /// </summary>
    /// <param name="EventName"></param>
    public void Invoke(string EventName)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo).action.Invoke();//����
        }
    }

    /// <summary>
    /// һ��ע�᷽��
    /// </summary>
    /// <param name="EventName"></param>
    /// <param name="Action"></param>
    public void Add<T>(string EventName, UnityAction<T> Action)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo<T>).action += Action;
        }
        else//û�а�������Ҫע��
        {
            UnityActionDic.Add(EventName, new EventInfo<T>(Action));
        }
    }

    /// <summary>
    /// һ��ȡ��ע�ắ��
    /// </summary>
    /// <param name="EventName"></param>
    /// <param name="Action"></param>
    public void Delete<T>(string EventName, UnityAction<T> Action)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo<T>).action -= Action;
        }
    }

    /// <summary>
    /// һ�δ�������
    /// </summary>
    /// <param name="EventName"></param>
    public void Invoke<T>(string EventName,T val)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo<T>).action.Invoke(val);//����
        }
    }

    /// <summary>
    /// ����ע�᷽��
    /// </summary>
    /// <param name="EventName"></param>
    /// <param name="Action"></param>
    public void Add<T1,T2>(string EventName, UnityAction<T1, T2> Action)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo<T1, T2>).action += Action;
        }
        else//û�а�������Ҫע��
        {
            UnityActionDic.Add(EventName, new EventInfo<T1, T2>(Action));
        }
    }

    /// <summary>
    /// ����ȡ��ע�ắ��
    /// </summary>
    /// <param name="EventName"></param>
    /// <param name="Action"></param>
    public void Delete<T1, T2>(string EventName, UnityAction<T1, T2> Action)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo<T1, T2>).action -= Action;
        }
    }

    /// <summary>
    /// ���δ�������
    /// </summary>
    /// <param name="EventName"></param>
    public void Invoke<T1, T2>(string EventName, T1 val1,T2 val2)
    {
        if (UnityActionDic.ContainsKey(EventName))//��ʾ�Ѿ��������¼�
        {
            (UnityActionDic[EventName] as EventInfo<T1, T2>).action.Invoke(val1,val2);//����
        }
        else
        {
            Debug.Log("û��" + EventName + "����¼�");
        }
    }

    /// <summary>
    /// �������ע���
    /// </summary>
    public void Clean()
    {
        UnityActionDic.Clear();
    }
}