using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EcosystemStrategy //生态系统构造策略
{
    /// <summary>
    /// 指定父物体，区块坐标，方块管理列表进行初始化
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="ChunkPosition"></param>
    /// <param name="ECubeList"></param>
    /// <returns></returns>
    public abstract IEnumerator ConstructEcosystem(GameObject parent, Vector2 ChunkPosition, ECube[,,] ECubeList);
}
