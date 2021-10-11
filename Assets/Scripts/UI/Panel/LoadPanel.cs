using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPanel : MonoBehaviour
{
    public UISystem uISystem;

    public Text PerCentText;//百分比显示
    public Scrollbar LoadingBar;//进度槽
    // Start is called before the first frame update
    int TasksNum;//任务总数
    int CurrtasksNum;//当前完成的任务总数
    float percent;//当前的完成率

    /// <summary>
    /// 设置任务总数
    /// </summary>
    /// <param name="tasks"></param>
    public void SetTasksNum(int tasks)
    {
        TasksNum = tasks;//设置任务总数
        LoadingBar.size = 0;//清空进度栏
        CurrtasksNum = 0;//清空当前完成的任务
    }

    /// <summary>
    /// 添加完成的任务数
    /// </summary>
    /// <param name="tasks"></param>
    public void AddTasksNum(int tasks)
    {
        //Debug.Log("设置任务" + tasks);
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
    /// 任务完成
    /// </summary>
    void TasksAchievement()
    {
        uISystem.TasksAchievement();
    }
}
