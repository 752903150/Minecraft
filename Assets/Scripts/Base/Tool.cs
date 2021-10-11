using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tool 
{
    /// <summary>
    /// ��ȡ��positionΪ����,���Ϊlen*len�������ε㼯
    /// </summary>
    /// <param name="position"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public static Vector2[,] GetCenter(Vector2 position, int len)
    {
        int startx = (int)position.x - len / 2;
        int starty = (int)position.y - len / 2;

        Vector2[,] temp = new Vector2[len, len];
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                temp[i, j] = new Vector2(startx + i, starty + j);
            }
        }
        return temp;
    }

    /// <summary>
    /// ���a-b�Ĳ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="am">a����</param>
    /// <param name="an">a����</param>
    /// <param name="bm">b����</param>
    /// <param name="bn">b����</param>
    /// <returns></returns>
    public static List<T> DifferentSet<T>(T[,] a, T[,] b, int am, int an, int bm, int bn)//���ȥ����ͬ����  ����a-b
    {
        HashSet<T> ab = new HashSet<T>();
        for (int i = 0; i < bn; i++)
        {
            for (int j = 0; j < bm; j++)
            {
                ab.Add(b[i, j]);
            }
        }

        List<T> temp = new List<T>();
        for (int i = 0; i < an; i++)
        {
            for (int j = 0; j < am; j++)
            {
                if (!ab.Contains(a[i, j]))
                {
                    temp.Add(a[i, j]);
                }
            }
        }
        return temp;
    }
}
