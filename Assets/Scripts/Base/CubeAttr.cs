using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������,����ID����������,�������ϲ��������Ƿ��ܹ�����
/// </summary>
public struct CubeAttr 
{
    public int id;//����ID
    public ECube eCube;//��������
    public int maxCombine;//�������ϲ�����
    public bool interaction;//�Ƿ��ܹ�����

    public CubeAttr(int _id,ECube _eCube,int _maxCombine,bool _interaction)
    {
        id = _id;
        eCube = _eCube;
        maxCombine = _maxCombine;
        interaction = _interaction;
    }
}
