using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色和地图通信的中介者系统,单例模式
/// </summary>
public class PlayerToMapMediaSystem : MonoBehaviour
{
    private static PlayerToMapMediaSystem instance;

    /// <summary>
    /// 获取角色和地图中介者的实例
    /// </summary>
    public static PlayerToMapMediaSystem Instance
    {
        get { 
            if(instance== null)
            {
                instance = new PlayerToMapMediaSystem();
            }
            return instance;
        }
    }

    
}
