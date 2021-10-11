using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public MediaSystem mediaSystem;//�н���ϵͳ

    public LoadPanel loadPanel;//�������


    private void Awake()
    {
        EventManagerSystem.Instance.Add<int>("������سɹ�", AddTasksNum);
        EventManagerSystem.Instance.Add<int>("���������������", SetTaskNum);
    }
    /// <summary>
    /// ������������
    /// </summary>
    /// <param name="tasks"></param>
    public void SetTaskNum(int tasks)
    {
        loadPanel.SetTasksNum(tasks);
    }

    /// <summary>
    /// ����Ѿ���ɵ�������
    /// </summary>
    /// <param name="tasks"></param>
    public void AddTasksNum(int tasks)
    {
        
        loadPanel.AddTasksNum(tasks);
    }

    /// <summary>
    /// �������
    /// </summary>
    public void TasksAchievement()
    {
        mediaSystem.TasksAchievement();
        loadPanel.GetComponent<ShowAndHide>().Hide();
    }
}
