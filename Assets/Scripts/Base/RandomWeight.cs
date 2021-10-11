using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeight 
{
    List<int> weight;//随机权重
    int sum = 0;//权重之和
    public RandomWeight(List<int> list)
    {
        weight = list;
        foreach(var i in list)
        {
            sum += i * 10;
        }
    }

    public void GetRandomElandform(int[] total,Elandform[,] EcologicalMap, float[,] random,int MapSize,float maxValue,float minValue)
    {
        int num = 0;
        //Debug.Log(maxValue+" "+minValue);
        float cha = maxValue - minValue;
        for(int i=0;i<MapSize;i++)
        {
            for(int j=0;j<MapSize;j++)
            {
                float ret = (random[i,j] - minValue) / cha;//计算出比率
                int val = (int)(sum * ret);//随机指针 *10是为了精度
                int index = 0;
                foreach (var k in weight)
                {
                    if (val <= k * 10)
                    {
                        //Debug.Log(ret + " " + val + " " + index);
                        //return index;
                        EcologicalMap[i, j] = (Elandform)index;
                        total[index]++;
                        num++;
                        //Debug.Log(num);
                        break;
                    }
                    else
                    {
                        val -= k * 10;
                    }
                    index++;
                }
            }
        }
    }
}
