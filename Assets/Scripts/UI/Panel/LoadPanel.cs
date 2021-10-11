using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    public UISystem uISystem;

    public Text PerCentText;//�ٷֱ���ʾ
    public Scrollbar LoadingBar;//���Ȳ�
    // Start is called before the first frame update
    int TasksNum;//��������
    int CurrtasksNum;//��ǰ��ɵ���������
    float percent;//��ǰ�������

    /// <summary>
    /// ������������
    /// </summary>
    /// <param name="tasks"></param>
    public void SetTasksNum(int tasks)
    {
        TasksNum = tasks;//������������
        LoadingBar.size = 0;//��ս�����
        CurrtasksNum = 0;//��յ�ǰ��ɵ�����
    }

    /// <summary>
    /// �����ɵ�������
    /// </summary>
    /// <param name="tasks"></param>
    public void AddTasksNum(int tasks)
    {
        //Debug.Log("��������" + tasks);
        CurrtasksNum += tasks;
        percent = (float)CurrtasksNum / TasksNum;
        PerCentText.text = Math.Round(percent*100,1).ToString()+"%";
        LoadingBar.size = percent;
        if(CurrtasksNum==TasksNum)
        {
            TasksAchievement();
        }
    }

    /// <summary>
    /// �������
    /// </summary>
    void TasksAchievement()
    {
        uISystem.TasksAchievement();
    }
}
