using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcologicalMaps : MonoBehaviour
{
    const int smooth = 2;//��̬ϵͳ�ľۼ��̶�
    const int MapSize = 10;
    static Elandform[,] EcologicalMap;//��̬��ͼ
    RandomWeight EcosystemWeight;//��̬ϵͳȨ���б�
    static int[] EcosystemTotal;

    private void Awake()
    {
        EcologicalMap = new Elandform[MapSize, MapSize];//��ʼ�������ͼ�Ĵ�С
        EcosystemWeight = new RandomWeight(GetWeightList());//��ʼ�����������
        EcosystemTotal = new int[(int)Elandform.ElandformCount];//��̬ϵͳ����
        ConstructMap();
    }
    public void ConstructMap()//�����ͼ�ӿ�
    {
        int ecologicalMapSeed = int.Parse(RandomBase.EcologicalMapSeed());//��ȡ��̬ϵͳ�������
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
                maxValue = Mathf.Max(maxValue, seedRandom);//��ȡ���߽�
                
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

    List<int> GetWeightList()//������̬ϵͳȨ���б�
    {
        List<int> temp = new List<int>();
        temp.Add(4);
        temp.Add(3);
        temp.Add(4);
        return temp;
    }
}
