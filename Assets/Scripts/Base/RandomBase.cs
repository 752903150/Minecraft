using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class RandomBase
{
    static string RandomSeed="1234567890";//随机种子，纯数字，十位

    public static string ToStandardRandomSeed(string RandomStr)//将玩家输入的随机字符处理成标准随机种子
    {
        int[] randombyte = {0,0,0,0,0,0,0,0,0,0};

        for(int i=0;i<RandomStr.Length;i++)
        {
            randombyte[i % 10] = (randombyte[i % 10] + RandomStr[i]) % 10;
        }

        StringBuilder stringBuilder = new StringBuilder(10);
        
        for(int i=0;i<10;i++)
        {
            stringBuilder.Append(randombyte[i].ToString());
        }

        return stringBuilder.ToString();
    }

    public static void SetRandomSeed(string seed)//设置随机种子
    {
        RandomSeed = seed;
    }

    public static string GetRandomSeed()//获得随机种子
    {
        return RandomSeed;
    }

    public static string EcologicalMapSeed()//生态地图随机种子
    {
        return RandomSeed.Substring(0, 2);
    }

    public static string EcologicalChunkSeed()//生态系统区块随机种子
    {
        return RandomSeed.Substring(1, 2);
    }
}
