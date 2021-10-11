using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public MediaSystem mediaSystem;//中介者系统

    public LoadPanel loadPanel;//加载面板


    private void Awake()
    {
        EventManagerSystem.Instance.Add<int>("方块加载成功", AddTasksNum);
        EventManagerSystem.Instance.Add<int>("方块总数计算完成", SetTaskNum);
    }
    /// <summary>
    /// 设置总任务数
    /// </summary>
    /// <param name="tasks"></param>
    public void SetTaskNum(int tasks)
    {
        loadPanel.SetTasksNum(tasks);
    }

    /// <summary>
    /// 添加已经完成的任务数
    /// </summary>
    /// <param name="tasks"></param>
    public void AddTasksNum(int tasks)
    {
        
        loadPanel.AddTasksNum(tasks);
    }

    /// <summary>
    /// 任务完成
    /// </summary>
    public void TasksAchievement()
    {
        mediaSystem.TasksAchievement();
        loadPanel.GetComponent<ShowAndHide>().Hide();
    }
}
