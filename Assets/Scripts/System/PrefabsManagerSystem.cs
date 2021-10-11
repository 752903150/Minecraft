using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsManagerSystem : MonoBehaviour
{
    static Dictionary<ECube, GameObject> Cubes;
    static Dictionary<ECube, Sprite> CubesTextures;//用于实例化
    static Dictionary<ECube, List<Sprite>> CubesTexturesPool;//用于储存被销毁的已经实例化的图片
    private void Awake()
    {
        Cubes = new Dictionary<ECube, GameObject>();
        CubesTextures = new Dictionary<ECube, Sprite>();
        CubesTexturesPool = new Dictionary<ECube, List<Sprite>>();

        for(int i=0;i<(int)ECube.NORMAL+1;i++)
        {
            CubesTexturesPool.Add((ECube)i, new List<Sprite>());
        }
        CreateCube();
        CreateCubeTexture();
        Debug.Log("初始化完毕");
    }
    public static GameObject GetObjectFromID(ECube eCube)
    {
        return Cubes[eCube];
    }

    public static Sprite GetCubeTextureFromID(ECube eCube)
    {
        Sprite temp;
        if (CubesTexturesPool[eCube].Count!=0)//图池中有
        {
            temp = CubesTexturesPool[eCube][0];
            CubesTexturesPool[eCube].RemoveAt(0);
        }
        else
        {
            temp = Instantiate(CubesTextures[eCube]);
        }
        return temp;
    }

    public static void BackCubeTexture(ECube eCube,Sprite sprite)
    {
        CubesTexturesPool[eCube].Add(sprite);
    }

    void CreateCube()
    {
        Cubes.Add(ECube.DIRCUBE, GetObj("Prefabs/Cube/DirtCube"));
        Cubes.Add(ECube.STONE, GetObj("Prefabs/Cube/StoneCube"));
        Cubes.Add(ECube.GREEN_GRASS, GetObj("Prefabs/Cube/GreenDirtCube"));
        Cubes.Add(ECube.SAND, GetObj("Prefabs/Cube/Sand"));
    }

    void CreateCubeTexture()
    {
        CubesTextures.Add(ECube.NORMAL, GetTexture("CubeTexture/000"));
        CubesTextures.Add(ECube.DIRCUBE, GetTexture("CubeTexture/003"));
        CubesTextures.Add(ECube.STONE, GetTexture("CubeTexture/001"));
        CubesTextures.Add(ECube.GREEN_GRASS, GetTexture("CubeTexture/002"));
        CubesTextures.Add(ECube.SAND, GetTexture("CubeTexture/004"));
    }

    static GameObject GetObj(string path)
    {
        return Resources.Load(path, typeof(GameObject)) as GameObject;
    }

    static Sprite GetTexture(string path)
    {
        return Resources.Load(path, typeof(Sprite)) as Sprite;
    }
}
