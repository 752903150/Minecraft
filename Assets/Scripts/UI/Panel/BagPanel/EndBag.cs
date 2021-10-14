using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBag : MonoBehaviour
{
    BagCell[] bagCells;//按钮集合
    FollowUI followUI;

    /// <summary>
    /// 快速移动物品，返回剩余的物品
    /// </summary>
    /// <param name="eCube"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public int FastAddObj(ECube eCube, int num)
    {
        ECube etemp;
        for (int i = 0; i < bagCells.Length; i++)
        {
            etemp = bagCells[i].GetCurrECube();
            if (etemp == ECube.NORMAL)
            {
                bagCells[i].SetObj(eCube, num);
                return 0;
            }
            else if (etemp == eCube)
            {
                int maxCombine = CubeAttrManager.GetCubeAttr(eCube).maxCombine;
                if (num + bagCells[i].GetObjNum() <= maxCombine)
                {
                    bagCells[i].SetObj(eCube, num + bagCells[i].GetObjNum());
                    return 0;
                }
                else if (bagCells[i].GetObjNum() == maxCombine)
                {
                    continue;
                }
                else
                {
                    num -= maxCombine - bagCells[i].GetObjNum();
                    bagCells[i].SetObj(eCube, maxCombine);
                }
            }
        }
        return num;
    }

    void Start()
    {
        bagCells = new BagCell[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            bagCells[i] = transform.GetChild(i).GetComponent<BagCell>();
            bagCells[i].SetID(i);
            bagCells[i].SetButtonOnClickedBack(ButtonOnLeftClicked, ButtonOnRightClicked, ButtonOnDoubleLeftClicked);
        }
    }

    void ButtonOnLeftClicked(int id)
    {
        if (Input.GetKey(KeyCode.R))
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
            ShiftLeftClick(id);
        }
        else
        {
            NormalLeftClick(id);
        }
    }

    void ButtonOnRightClicked(int id)
    {
        if (Input.GetKey(KeyCode.R))
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
            ShiftRightClick(id);
        }
        else
        {
            NormalRightClick(id);
        }
    }

    void ButtonOnDoubleLeftClicked(int id)
    {
        Debug.Log("双击");
    }
    void NormalLeftClick(int id)//左键单击
    {
        int objnum = bagCells[id].GetObjNum();
        ECube eCube = bagCells[id].GetCurrECube();
        if (eCube == ECube.NORMAL)//点的格子没有物体
        {
            int followObjNum = followUI.GetObjNum();
            ECube followECube = followUI.GetCurrECube();
            if (followECube == ECube.NORMAL)//鼠标上面也没有拿起物品
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
            if (followECube == ECube.NORMAL)//鼠标上面没有物体
            {
                Debug.Log("存放物体到鼠标");
                followUI.SetObj(eCube, objnum);//这条语句相当于清空
                bagCells[id].SetObj(ECube.NORMAL, 0);//在指定格子存放物体
            }
            else if (followECube == eCube)//存放的物品相同则进行合并操作
            {
                int maxCombine = CubeAttrManager.GetCubeAttr(eCube).maxCombine;//获取最大合并数量
                Debug.Log(maxCombine + " " + objnum + " " + followObjNum);
                if (followObjNum + objnum <= maxCombine)//如果在合并数量范围内
                {
                    followUI.SetObj(ECube.NORMAL, 0);//这条语句相当于清空
                    bagCells[id].SetObj(eCube, followObjNum + objnum);//在指定格子存放物体
                }
                else
                {
                    followUI.SetObj(eCube, followObjNum + objnum - maxCombine);
                    bagCells[id].SetObj(eCube, maxCombine);//在指定格子存放物体
                }
                Debug.Log("合并物体");
            }
            else//鼠标上面有物体但与格子上的物品不同
            {
                Debug.Log("物品不能合并");
            }
        }
    }

    void NormalRightClick(int id)//右键单击
    {
        int objnum = bagCells[id].GetObjNum();
        ECube eCube = bagCells[id].GetCurrECube();
        if (eCube == ECube.NORMAL)//点的格子没有物体
        {
            int followObjNum = followUI.GetObjNum();
            ECube followECube = followUI.GetCurrECube();
            if (followECube == ECube.NORMAL)//鼠标上面也没有拿起物品
            {
                Debug.Log("无操作");
            }
            else//鼠标上面拿起了物体
            {
                Debug.Log("存放物体");
                followUI.SubNum();//数值减1
                bagCells[id].SetObj(followECube, 1);//在指定格子存放一个物体
            }
        }
        else//点的格子有物体
        {
            int followObjNum = followUI.GetObjNum();
            ECube followECube = followUI.GetCurrECube();
            if (followECube == ECube.NORMAL)//鼠标上面没有物体
            {
                Debug.Log("拿取一半的物体");
                followUI.SetObj(eCube, objnum / 2);
                bagCells[id].SetObj(eCube, objnum - objnum / 2);
            }
            else if (followECube == eCube)//存放的物品相同则进行合并操作
            {
                int maxCombine = CubeAttrManager.GetCubeAttr(eCube).maxCombine;//获取最大合并数量
                Debug.Log(maxCombine + " " + objnum + " " + followObjNum);
                if (1 + objnum <= maxCombine)//如果在合并数量范围内
                {
                    followUI.SubNum();
                    bagCells[id].SetObj(eCube, 1 + objnum);//物体+1
                }
                else
                {
                    Debug.Log("格子已满，不能合并物体");
                }
                Debug.Log("合并物体");
            }
            else//鼠标上面有物体但与格子上的物品不同
            {
                Debug.Log("物品不能合并");
            }
        }
    }
    void ShiftLeftClick(int id)//左键+Shift单击
    {

    }
    void ShiftRightClick(int id)//右键+Shift单击
    {

    }
    public void SetFollow(FollowUI followUI)
    {
        this.followUI = followUI;
    }
}
