using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EcosystemStrategy //��̬ϵͳ�������
{
    /// <summary>
    /// ָ�������壬�������꣬��������б���г�ʼ��
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="ChunkPosition"></param>
    /// <param name="ECubeList"></param>
    /// <returns></returns>
    public abstract IEnumerator ConstructEcosystem(GameObject parent, Vector2 ChunkPosition, ECube[,,] ECubeList);
}
