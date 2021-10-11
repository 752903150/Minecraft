using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerSystem : MonoBehaviour
{
    public MediaSystem mediaSystem;//中介者系统
    public GameObject Player;//角色系统，强相关

    public GameObject PreMapChunk;//地图区块预制体


    Dictionary<Vector2, MapChunk> MapChunks;//地图区块容器
    Vector2 playerChunk = Vector2.zero;//角色区块编号
    int[] DirectionX = {1,1,0,-1,-1,-1,0,1};//逆时针遍历周围8个方向
    int[] DirectionY = {0,1,1,1,0,-1,-1,-1};
    bool PlayerInit;//角色初始化标志
    int TotalCubeNum;//初始化方块总数
    int DefaultChunkNum;//初始化区块数量
    void Awake()
    {
        EventManagerSystem.Instance.Add<Vector3,GameObject>("破坏方块", BreakCube);
        EventManagerSystem.Instance.Add<int>("计算区块方块数量", TotalCubeBack);
        EventManagerSystem.Instance.Add("区块加载成功", ChunkAchievementBack);
        //EventManagerSystem.Instance.Add<Vector3, GameObject>("方块加载成功", BreakCube);

        MapChunks = new Dictionary<Vector2, MapChunk>();//初始化默认区块数量
        PlayerInit = false;//初始化角色为未加载
        TotalCubeNum = 0;//初始化方块数为0
        Player.GetComponent<PlayerMove>().SetGravity(0);//取消重力
    }
    private void Start()
    {
        DefaultChunkNum = BaseConfig.DefaultChunkLengthNum * BaseConfig.DefaultChunkWeightNum;
        for (int i = 0; i < BaseConfig.DefaultChunkLengthNum; i++)
        {
            for (int j = 0; j < BaseConfig.DefaultChunkWeightNum; j++)
            {
                CreateChunk(new Vector2(i, j));
            }
        }
        StartCoroutine(ChunkRefresh());
    }
    /// <summary>
    /// 加载角色
    /// </summary>
    public void CreatePlayer()
    {
        /*GameObject temp = Instantiate<GameObject>(Player);//角色实例化
        Player = temp;
        Player.transform.localPosition = new Vector3(0f, 70f, 0f);*/
        Player.GetComponent<PlayerMove>().SetGravity(1);//恢复重力
        PlayerInit = true;
    }

    /// <summary>
    /// 角色放置方块，需要方块坐标(世界坐标)和方块类型
    /// </summary>
    /// <param name="l"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="eCube"></param>
    public void SetCube(int l, int w, int h, ECube eCube)
    {
        //计算区块
        int chunkX = l / BaseConfig.ChunkLength;
        int chunkY = w / BaseConfig.ChunkWeight;

        MapChunks[new Vector2(chunkX, chunkY)].SetCube(l % BaseConfig.ChunkLength, w % BaseConfig.ChunkWeight, h,eCube);
    }
    /// <summary>
    /// 破坏方块，需要方块坐标,和待摧毁的方块
    /// </summary>
    /// <param name="l"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="Cube"></param>
    public void BreakCube(int l, int w, int h, GameObject Cube)
    {
        //计算区块
        int chunkX = l / BaseConfig.ChunkLength;
        int chunkY = w / BaseConfig.ChunkWeight;
        if (MapChunks.ContainsKey(new Vector2(chunkX, chunkY)))
            MapChunks[new Vector2(chunkX, chunkY)].BreakCube(l % BaseConfig.ChunkLength, w % BaseConfig.ChunkWeight, h, Cube);
        else
            Debug.Log("该区块未加载？");
    }

    public void BreakCube(Vector3 Position, GameObject Cube)
    {
        //计算区块
        int chunkX = (int)Position.x / BaseConfig.ChunkLength;
        int chunkY = (int)Position.z / BaseConfig.ChunkWeight;
        if (MapChunks.ContainsKey(new Vector2(chunkX, chunkY)))
            MapChunks[new Vector2(chunkX, chunkY)].BreakCube(
                (int)Position.x % BaseConfig.ChunkLength, 
                (int)Position.z % BaseConfig.ChunkWeight, 
                (int)Position.y, 
                Cube);
        else
            Debug.Log("该区块未加载？");
    }
    IEnumerator ChunkRefresh()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);//刷新间隔
            if(!PlayerInit)
            {
                continue;
            }
            int x = (int)Mathf.Floor(Player.transform.localPosition.x / BaseConfig.ChunkLength);//新的坐标
            int y = (int)Mathf.Floor(Player.transform.localPosition.z / BaseConfig.ChunkWeight);

            if (x != playerChunk.x || y != playerChunk.y)//如果跟上一次不相同的话就会执行区块刷新检测
            {
                int lastx = (int)playerChunk.x;//旧的坐标
                int lasty = (int)playerChunk.y;

                playerChunk.x = x;//更新当前区块坐标
                playerChunk.y = y;

                Vector2[,] newCenter = Tool.GetCenter(new Vector2(x, y), BaseConfig.VisibleChunkLength);//新的中心集合
                Vector2[,] lastCenter = Tool.GetCenter(new Vector2(lastx, lasty), BaseConfig.VisibleChunkLength);//旧的中心集合

                List<Vector2> unvisibleList = Tool.DifferentSet<Vector2>(lastCenter,newCenter, 
                    BaseConfig.VisibleChunkLength, BaseConfig.VisibleChunkLength, 
                    BaseConfig.VisibleChunkLength, BaseConfig.VisibleChunkLength);

                for(int i=0;i<BaseConfig.VisibleChunkLength;i++)//显示
                {
                    for(int j=0;j<BaseConfig.VisibleChunkLength;j++)
                    {
                        if (MapChunks.ContainsKey(newCenter[i, j])) //如果在实例化字典里面
                        {
                            MapChunks[newCenter[i, j]].SetVisible(true);
                        }
                        else//如果不在
                        {
                            CreateChunk(newCenter[i, j]);//实例化区块并显示
                        }
                    }
                }

                for(int i=0;i<unvisibleList.Count;i++)//隐藏
                {
                    if (MapChunks.ContainsKey(unvisibleList[i]))//如果在实例化列表里面
                    {
                        MapChunks[unvisibleList[i]].SetVisible(false);
                    }
                }
            }
        }  
    }

    void CreateChunk(Vector2 position)
    {
        GameObject tempp = Instantiate<GameObject>(PreMapChunk);//区块实例化
        tempp.transform.SetParent(this.transform);
        tempp.transform.position = new Vector3(position.x * BaseConfig.ChunkLength, 0, position.y * BaseConfig.ChunkWeight);
        MapChunk tempChunk = tempp.GetComponent<MapChunk>();
        tempChunk.LoadMap((int)position.x, (int)position.y);
        MapChunks.Add(position, tempp.GetComponent<MapChunk>());
    }

    void ChunkAchievementBack()
    {
        Debug.Log("区块加载完毕");
        //mediaSystem.AddTasksNum(1);
    }

    void TotalCubeBack(int num)
    {
        TotalCubeNum += num;
        DefaultChunkNum--;
        if(DefaultChunkNum==0)
        {
            Debug.Log("设置任务总数完成=" + TotalCubeNum);
            EventManagerSystem.Instance.Invoke("方块总数计算完成", TotalCubeNum);
        }
    }
}
