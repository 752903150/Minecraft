using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBag : MonoBehaviour
{
    BagCell[] bagCells;//按钮集合
    FollowUI followUI;
    void Start()
    {
        bagCells = new BagCell[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            bagCells[i] = transform.GetChild(i).GetComponent<BagCell>();
            bagCells[i].SetID(i);
            bagCells[i].SetButtonOnClickedBack(ButtonOnClicked);
        }
    }

    void ButtonOnClicked(int id)
    {
        if(Input.GetKey(KeyCode.R))
        {
            Debug.Log("按下了R键");
            bagCells[id].SetObj(ECube.STONE, 64);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("按下了左Ctrl键");
            bagCells[id].SetObj(ECube.STONE, 3);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("按下了左Shift键");
            bagCells[id].SetObj(ECube.SAND, 2);
        }
        else
        {
            int objnum = bagCells[id].GetObjNum();
            ECube eCube = bagCells[id].GetCurrECube();
            if(eCube==ECube.NORMAL)//点的格子没有物体
            {
                int followObjNum = followUI.GetObjNum();
                ECube followECube = followUI.GetCurrECube();
                if(followECube==ECube.NORMAL)//鼠标上面也没有拿起物品
                {
                    Debug.Log("无操作");
                }
                else//鼠标上面拿起了物体
                {
                    Debug.Log("存放物体");
                    followUI.SetObj(ECube.NORMAL, 0);//这条语句相当于清空
                    bagCells[id].SetObj(followECube, followObjNum);//在指定格子存放物体
                }
            }
            else//点的格子有物体
            {
                int followObjNum = followUI.GetObjNum();
                ECube followECube = followUI.GetCurrECube();
                if(followECube==ECube.NORMAL)
                {
                    Debug.Log("存放物体到鼠标");
                    followUI.SetObj(eCube, objnum);//这条语句相当于清空
                    bagCells[id].SetObj(ECube.NORMAL, 0);//在指定格子存放物体
                }
                else if (followECube == eCube)//存放的物品相同则进行合并操作
                {
                    int maxCombine = CubeAttrManager.GetCubeAttr(eCube).maxCombine;//获取最大合并数量
                    Debug.Log(maxCombine + " " + objnum + " " + followObjNum);
                    if(followObjNum+objnum<=maxCombine)//如果在合并数量范围内
                    {
                        followUI.SetObj(ECube.NORMAL, 0);//这条语句相当于清空
                        bagCells[id].SetObj(eCube, followObjNum+objnum);//在指定格子存放物体
                    }
                    else
                    {
                        followUI.SetObj(eCube, followObjNum + objnum - maxCombine);
                        bagCells[id].SetObj(eCube, maxCombine);//在指定格子存放物体
                    }
                    Debug.Log("合并物体");
                }
                else//鼠标上面拿起了物体
                {
                    Debug.Log("物品不能合并");
                }
            }
        }
    }

    public void SetFollow(FollowUI followUI)
    {
        this.followUI = followUI;
    }
}
