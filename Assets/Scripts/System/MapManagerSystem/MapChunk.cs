using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunk : MonoBehaviour
{
    EcosystemStrategy ecosystemStrategy;//生态系统构造策略

    Elandform elandform;//区块生态

    ECube[,,] ECubeList;//方块管理列表,长宽高，大概256KB，

    private void Awake()
    {
        ECubeList = new ECube[BaseConfig.ChunkLength, BaseConfig.ChunkWeight, BaseConfig.ChunkHeight];
        
    }
    /// <summary>
    /// 加载区块
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void LoadMap(int x,int y)
    {
        Elandform e = EcologicalMaps.GetEcosystem(x, y);//获取当前的生态系统
        switch(e)
        {
            case Elandform.prairie://草原
                {
                    //Debug.Log("草原");
                    //EcosystemTotal[(int)Elandform.prairie]++;
                    ecosystemStrategy = new GrasslandStrategy();
                    break;
                }
            case Elandform.mountain://高山
                {
                    //Debug.Log("高山");
                    //EcosystemTotal[(int)Elandform.mountain]++;
                    ecosystemStrategy = new StoneMountainStrategy();
                    break;
                }
            case Elandform.desert://沙漠
                {
                    //EcosystemTotal[(int)Elandform.desert]++;
                    ecosystemStrategy = new DesertStrategy();
                    break;
                }
            default://空
                {
                    ecosystemStrategy = new GrasslandStrategy();
                    break;
                }
        }
        StartCoroutine(ecosystemStrategy.ConstructEcosystem(this.gameObject,new Vector2(x,y), ECubeList));
    }
    /// <summary>
    /// 设置区块可见性
    /// </summary>
    /// <param name="flag"></param>
    public void SetVisible(bool flag)
    {
        gameObject.SetActive(flag);
    }
    /// <summary>
    /// 返回当前区块的生态系统
    /// </summary>
    /// <returns></returns>
    public Elandform GetElandform()
    {
        return elandform;
    }
    /// <summary>
    /// 获取指定坐标的方块类型,需要 x,z,y坐标
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public ECube GetECube(int l,int w,int h)
    {
        return ECubeList[l, w, h];
    }
    /// <summary>
    /// 角色放置方块，需要方块坐标(世界坐标)和方块类型
    /// </summary>
    /// <param name="l"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="eCube"></param>
    public void SetCube(int l, int w, int h, ECube eCube)
    {
        if(ECubeList[l,w,h]==ECube.NORMAL)
        {
            ECubeList[l, w, h] = eCube;
            GameObject temp;
            temp = PrefabsManagerSystem.GetObjectFromID(ECube.STONE);
            temp = GameObject.Instantiate(temp);
            temp.transform.SetParent(transform);
            temp.transform.localPosition = new Vector3(l,h,w);//初始化位置
        }
        
    }
    /// <summary>
    /// 破坏方块，需要方块坐标
    /// </summary>
    /// <param name="l"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    public void BreakCube(int l, int w, int h,GameObject Cube)
    {
        if (ECubeList[l, w, h] != ECube.NORMAL)
        {
            ECubeList[l, w, h] = ECube.NORMAL;
            Destroy(Cube);
        }
        else
        {

        }
    }
}
