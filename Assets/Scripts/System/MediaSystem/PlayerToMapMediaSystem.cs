using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ɫ�͵�ͼͨ�ŵ��н���ϵͳ,����ģʽ
/// </summary>
public class PlayerToMapMediaSystem : MonoBehaviour
{
    private static PlayerToMapMediaSystem instance;

    /// <summary>
    /// ��ȡ��ɫ�͵�ͼ�н��ߵ�ʵ��
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
