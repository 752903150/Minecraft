using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertStrategy : EcosystemStrategy//��ԭ����
{
    const int chunkset = 2;//����ƫ�Ƴɶ�
    const int cuberet = 1;//λ��ƫ�Ƴ̶�
    const int mapSize = 100;//����ƽ����,Խ��Խƽ��

    const int maxHeight = 30;//��߸߶�
    const int minHeight = 10;//��߸߶�

    public override IEnumerator ConstructEcosystem(GameObject parent, Vector2 ChunkPosition, ECube[,,] ECubeList)
    {

        for (int i = 0; i < BaseConfig.ChunkLength; i++)
        {
            for (int j = 0; j < BaseConfig.ChunkWeight; j++)
            {
                for (int k = 0; k < BaseConfig.ChunkHeight; k++)
                {
                    ECubeList[i, j, k] = ECube.NORMAL;
                }
            }
        }

        int GrasslandSeed = int.Parse(RandomBase.EcologicalChunkSeed());//��ȡ��̬ϵͳ�������
                                                                        //Debug.Log(ChunkPosition.x * BaseConfig.ChunkLength  + " " + GrasslandSeed + " " + ChunkPosition.y * BaseConfig.ChunkWeight  + " " + GrasslandSeed);
                                                                        //��ʼ���߶�ͼ
        int[,] heights = new int[16, 16];
        List<Vector2> position = new List<Vector2>();
        int sum = 0;
        for (int j = 0; j < BaseConfig.ChunkWeight; j++)//��16
        {
            for (int i = 0; i < BaseConfig.ChunkLength; i++)//����16
            {
                position.Add(new Vector2(i, j));
                float xrandom = Mathf.Abs((ChunkPosition.x * BaseConfig.ChunkLength + i * cuberet + ChunkPosition.x * chunkset)
                        % (mapSize + GrasslandSeed + ChunkPosition.x * BaseConfig.ChunkLength))
                        / (mapSize + GrasslandSeed + ChunkPosition.x * BaseConfig.ChunkLength);
                float yrandom = Mathf.Abs((ChunkPosition.y * BaseConfig.ChunkWeight + j * cuberet + ChunkPosition.y * chunkset)
                    % (mapSize + GrasslandSeed + ChunkPosition.y * BaseConfig.ChunkLength))
                    / (mapSize + GrasslandSeed + ChunkPosition.y * BaseConfig.ChunkLength);
                float temp = Mathf.PerlinNoise(xrandom, yrandom);
                heights[i, j] = (int)Mathf.Lerp(minHeight,
                    maxHeight,
                    temp);
                sum += heights[i, j];
                //�߶����ȡ��
                //Debug.Log(temp);
                //Debug.Log(ChunkPosition.x * BaseConfig.ChunkLength* j + GrasslandSeed+" "+ ChunkPosition.y * BaseConfig.ChunkWeight* i + GrasslandSeed);
            }
            //yield return null;
        }
        //��ɷ��������ļ���
        EventManagerSystem.Instance.Invoke<int>("�������鷽������", sum);
        int loadnum = 0;
        while (position.Count != 0)
        {
            for (int i = 0; i < position.Count; i++)
            {
                int x = (int)position[i].x;
                int y = (int)position[i].y;
                if (heights[x, y] == 0)//��һ�й������
                {
                    position.RemoveAt(i);
                    continue;
                }
                ECubeList[(int)position[i].x, (int)position[i].y, (int)heights[(int)position[i].x, (int)position[i].y]] = ECube.SAND;
                GameObject temp;
                temp = PrefabsManagerSystem.GetObjectFromID(ECube.SAND);
                temp = UnityEngine.GameObject.Instantiate(temp);
                temp.transform.SetParent(parent.transform);
                temp.transform.localPosition = new Vector3(position[i].x,
                    heights[(int)position[i].x, (int)position[i].y],
                    position[i].y);//��ʼ��λ��


                heights[(int)position[i].x, (int)position[i].y]--;
                loadnum++;
                if (loadnum / BaseConfig.CubeLoadBackRet > 1)
                {
                    EventManagerSystem.Instance.Invoke<int>("������سɹ�", BaseConfig.CubeLoadBackRet);
                    loadnum -= BaseConfig.CubeLoadBackRet;
                }
                if (i % 2 == 0)//��������
                    yield return null;
            }
        }
        EventManagerSystem.Instance.Invoke<int>("������سɹ�", loadnum);
        EventManagerSystem.Instance.Invoke("������سɹ�");
    }
}
