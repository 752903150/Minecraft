using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 方块属性,方块ID，方块种类,方块最大合并数量，是否能够交互
/// </summary>
public struct CubeAttr 
{
    public int id;//方块ID
    public ECube eCube;//方块种类
    public int maxCombine;//方块最大合并数量
    public bool interaction;//是否能够交互

    public CubeAttr(int _id,ECube _eCube,int _maxCombine,bool _interaction)
    {
        id = _id;
        eCube = _eCube;
        maxCombine = _maxCombine;
        interaction = _interaction;
    }
}
