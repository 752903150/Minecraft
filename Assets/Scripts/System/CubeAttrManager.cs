using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAttrManager : MonoBehaviour
{
    static List<CubeAttr> cubeAttrs;

    private void Start()
    {
        cubeAttrs = new List<CubeAttr>();
        AddAttr();
    }

    void AddAttr()
    {
        cubeAttrs.Add(new CubeAttr(1, ECube.DIRCUBE, 64, false));
        cubeAttrs.Add(new CubeAttr(2, ECube.GREEN_GRASS, 64, false));
        cubeAttrs.Add(new CubeAttr(3, ECube.STONE, 64, false));
        cubeAttrs.Add(new CubeAttr(4, ECube.SAND, 64, false));
    }

    public static CubeAttr GetCubeAttr(int id)
    {
        return cubeAttrs[id - 1];
    }

    public static CubeAttr GetCubeAttr(ECube eCube)
    {
        return cubeAttrs[(int)eCube - 1];
    }
}
