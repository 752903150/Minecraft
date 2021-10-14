using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBag : MonoBehaviour
{
    BagCell[] bagCells;//��ť����
    FollowUI followUI;

    /// <summary>
    /// �����ƶ���Ʒ������ʣ�����Ʒ
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
            Debug.Log("������R��");
            bagCells[id].SetObj(ECube.STONE, 64);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("��������Ctrl��");
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
            Debug.Log("������R��");
            bagCells[id].SetObj(ECube.STONE, 64);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("��������Ctrl��");
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
        Debug.Log("˫��");
    }
    void NormalLeftClick(int id)//�������
    {
        int objnum = bagCells[id].GetObjNum();
        ECube eCube = bagCells[id].GetCurrECube();
        if (eCube == ECube.NORMAL)//��ĸ���û������
        {
            int followObjNum = followUI.GetObjNum();
            ECube followECube = followUI.GetCurrECube();
            if (followECube == ECube.NORMAL)//�������Ҳû��������Ʒ
            {
                Debug.Log("�޲���");
            }
            else//�����������������
            {
                Debug.Log("�������");
                followUI.SetObj(ECube.NORMAL, 0);//��������൱�����
                bagCells[id].SetObj(followECube, followObjNum);//��ָ�����Ӵ������
            }
        }
        else//��ĸ���������
        {
            int followObjNum = followUI.GetObjNum();
            ECube followECube = followUI.GetCurrECube();
            if (followECube == ECube.NORMAL)//�������û������
            {
                Debug.Log("������嵽���");
                followUI.SetObj(eCube, objnum);//��������൱�����
                bagCells[id].SetObj(ECube.NORMAL, 0);//��ָ�����Ӵ������
            }
            else if (followECube == eCube)//��ŵ���Ʒ��ͬ����кϲ�����
            {
                int maxCombine = CubeAttrManager.GetCubeAttr(eCube).maxCombine;//��ȡ���ϲ�����
                Debug.Log(maxCombine + " " + objnum + " " + followObjNum);
                if (followObjNum + objnum <= maxCombine)//����ںϲ�������Χ��
                {
                    followUI.SetObj(ECube.NORMAL, 0);//��������൱�����
                    bagCells[id].SetObj(eCube, followObjNum + objnum);//��ָ�����Ӵ������
                }
                else
                {
                    followUI.SetObj(eCube, followObjNum + objnum - maxCombine);
                    bagCells[id].SetObj(eCube, maxCombine);//��ָ�����Ӵ������
                }
                Debug.Log("�ϲ�����");
            }
            else//������������嵫������ϵ���Ʒ��ͬ
            {
                Debug.Log("��Ʒ���ܺϲ�");
            }
        }
    }

    void NormalRightClick(int id)//�Ҽ�����
    {
        int objnum = bagCells[id].GetObjNum();
        ECube eCube = bagCells[id].GetCurrECube();
        if (eCube == ECube.NORMAL)//��ĸ���û������
        {
            int followObjNum = followUI.GetObjNum();
            ECube followECube = followUI.GetCurrECube();
            if (followECube == ECube.NORMAL)//�������Ҳû��������Ʒ
            {
                Debug.Log("�޲���");
            }
            else//�����������������
            {
                Debug.Log("�������");
                followUI.SubNum();//��ֵ��1
                bagCells[id].SetObj(followECube, 1);//��ָ�����Ӵ��һ������
            }
        }
        else//��ĸ���������
        {
            int followObjNum = followUI.GetObjNum();
            ECube followECube = followUI.GetCurrECube();
            if (followECube == ECube.NORMAL)//�������û������
            {
                Debug.Log("��ȡһ�������");
                followUI.SetObj(eCube, objnum / 2);
                bagCells[id].SetObj(eCube, objnum - objnum / 2);
            }
            else if (followECube == eCube)//��ŵ���Ʒ��ͬ����кϲ�����
            {
                int maxCombine = CubeAttrManager.GetCubeAttr(eCube).maxCombine;//��ȡ���ϲ�����
                Debug.Log(maxCombine + " " + objnum + " " + followObjNum);
                if (1 + objnum <= maxCombine)//����ںϲ�������Χ��
                {
                    followUI.SubNum();
                    bagCells[id].SetObj(eCube, 1 + objnum);//����+1
                }
                else
                {
                    Debug.Log("�������������ܺϲ�����");
                }
                Debug.Log("�ϲ�����");
            }
            else//������������嵫������ϵ���Ʒ��ͬ
            {
                Debug.Log("��Ʒ���ܺϲ�");
            }
        }
    }
    void ShiftLeftClick(int id)//���+Shift����
    {

    }
    void ShiftRightClick(int id)//�Ҽ�+Shift����
    {

    }
    public void SetFollow(FollowUI followUI)
    {
        this.followUI = followUI;
    }
}
