using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tool 
{
    /// <summary>
    /// 获取以position为中心,面积为len*len的正方形点集
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
    /// 差集，a-b的部分
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="am">a的列</param>
    /// <param name="an">a的行</param>
    /// <param name="bm">b的列</param>
    /// <param name="bn">b的行</param>
    /// <returns></returns>
    public static List<T> DifferentSet<T>(T[,] a, T[,] b, int am, int an, int bm, int bn)//叉积去掉共同部分  返回a-b
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
