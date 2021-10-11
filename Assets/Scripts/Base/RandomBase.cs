using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class RandomBase
{
    static string RandomSeed="1234567890";//������ӣ������֣�ʮλ

    public static string ToStandardRandomSeed(string RandomStr)//��������������ַ�����ɱ�׼�������
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

    public static void SetRandomSeed(string seed)//�����������
    {
        RandomSeed = seed;
    }

    public static string GetRandomSeed()//����������
    {
        return RandomSeed;
    }

    public static string EcologicalMapSeed()//��̬��ͼ�������
    {
        return RandomSeed.Substring(0, 2);
    }

    public static string EcologicalChunkSeed()//��̬ϵͳ�����������
    {
        return RandomSeed.Substring(1, 2);
    }
}
