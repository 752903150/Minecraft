using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaSystem : MonoBehaviour
{
    public UISystem uISystem;//UI系统
    public MapManagerSystem mapManagerSystem;//地图控制系统
    /// <summary>
    /// 设置光标可见性
    /// </summary>
    /// <param name="flag"></param>
    public void SetCursorVisible(bool flag)
    {
        Cursor.visible = false;
    }

    /// <summary>
    /// 设置光标锁定模式
    /// </summary>
    /// <param name="cursorLockMode"></param>
    public void SetCursorLock(CursorLockMode cursorLockMode)
    {
        Cursor.lockState = cursorLockMode;
    }

    /// <summary>
    /// 设置加载面板总任务数
    /// </summary>
    /// <param name="tasks"></param>
    public void SetTasksNum(int tasks)
    {
        uISystem.SetTaskNum(tasks);
    }

    /// <summary>
    /// 添加已经完成的任务数
    /// </summary>
    /// <param name="tasks"></param>
    public void AddTasksNum(int tasks)
    {
        uISystem.AddTasksNum(tasks);
    }

    /// <summary>
    /// 加载任务完成
    /// </summary>
    public void TasksAchievement()
    {
        mapManagerSystem.CreatePlayer();
    }
}
