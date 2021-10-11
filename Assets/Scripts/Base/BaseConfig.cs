using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BaseConfig 
{
    public const int DefaultChunkLengthNum = 3;//默认区块长度
    public const int DefaultChunkWeightNum = 3;//默认区块长度

    public const int VisibleChunkLength = 5;//区块刷新范围

    public const int ChunkLength = 16;//区块长度
    public const int ChunkWeight = 16;//区块宽度
    public const int ChunkHeight = 40;//区块高度

    public const int CubeLoadBackRet = 500;//方块加载成功事件回调速率，数值越大回调的次数越少，进度条越不平滑
}
