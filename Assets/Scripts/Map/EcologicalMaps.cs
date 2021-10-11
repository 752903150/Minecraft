using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcologicalMaps : MonoBehaviour
{
    const int smooth = 2;//生态系统的聚集程度
    const int MapSize = 10;
    static Elandform[,] EcologicalMap;//生态地图
    RandomWeight EcosystemWeight;//生态系统权重列表
    static int[] EcosystemTotal;

    private void Awake()
    {
        EcologicalMap = new Elandform[MapSize, MapSize];//初始化随机地图的大小
        EcosystemWeight = new RandomWeight(GetWeightList());//初始化随机构造器
        EcosystemTotal = new int[(int)Elandform.ElandformCount];//生态系统总数
        ConstructMap();
    }
    public void ConstructMap()//构造地图接口
    {
        int ecologicalMapSeed = int.Parse(RandomBase.EcologicalMapSeed());//获取生态系统随机种子
        float[,] temp = new float[MapSize, MapSize];
        float minValue = 1;
        float maxValue = 0;
        for(int i=0;i<MapSize;i++)
        {
            for(int j =0;j<MapSize;j++)
            {
                float seedRandom = Mathf.PerlinNoise((float)(i % (MapSize / smooth)) / (MapSize / smooth + ecologicalMapSeed), 
                                                    (float)(j % (MapSize / smooth)) / (MapSize / smooth + ecologicalMapSeed));
                temp[i, j] = seedRandom;
                minValue = Mathf.Min(minValue, seedRandom);
                maxValue = Mathf.Max(maxValue, seedRandom);//获取最大边界
                
            }
        }

        EcosystemWeight.GetRandomElandform(EcosystemTotal,EcologicalMap, temp,MapSize,maxValue,minValue);
    }

    public static Elandform GetEcosystem(int x,int y)
    {
        //Debug.Log(x + " " + y);
        return EcologicalMap[Mathf.Abs(x) % MapSize, Mathf.Abs(y) % MapSize];
    }

    public static int[] GetEcosystemTotal()
    {
        return EcosystemTotal;
    }

    List<int> GetWeightList()//设置生态系统权重列表
    {
        List<int> temp = new List<int>();
        temp.Add(4);
        temp.Add(3);
        temp.Add(4);
        return temp;
    }
}
