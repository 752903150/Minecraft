using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBag : MonoBehaviour
{
    BagCell[] bagCells;//��ť����
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
            Debug.Log("��������Shift��");
            bagCells[id].SetObj(ECube.SAND, 2);
        }
        else
        {
            int objnum = bagCells[id].GetObjNum();
            ECube eCube = bagCells[id].GetCurrECube();
            if(eCube==ECube.NORMAL)//��ĸ���û������
            {
                int followObjNum = followUI.GetObjNum();
                ECube followECube = followUI.GetCurrECube();
                if(followECube==ECube.NORMAL)//�������Ҳû��������Ʒ
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
                if(followECube==ECube.NORMAL)
                {
                    Debug.Log("������嵽���");
                    followUI.SetObj(eCube, objnum);//��������൱�����
                    bagCells[id].SetObj(ECube.NORMAL, 0);//��ָ�����Ӵ������
                }
                else if (followECube == eCube)//��ŵ���Ʒ��ͬ����кϲ�����
                {
                    int maxCombine = CubeAttrManager.GetCubeAttr(eCube).maxCombine;//��ȡ���ϲ�����
                    Debug.Log(maxCombine + " " + objnum + " " + followObjNum);
                    if(followObjNum+objnum<=maxCombine)//����ںϲ�������Χ��
                    {
                        followUI.SetObj(ECube.NORMAL, 0);//��������൱�����
                        bagCells[id].SetObj(eCube, followObjNum+objnum);//��ָ�����Ӵ������
                    }
                    else
                    {
                        followUI.SetObj(eCube, followObjNum + objnum - maxCombine);
                        bagCells[id].SetObj(eCube, maxCombine);//��ָ�����Ӵ������
                    }
                    Debug.Log("�ϲ�����");
                }
                else//�����������������
                {
                    Debug.Log("��Ʒ���ܺϲ�");
                }
            }
        }
    }

    public void SetFollow(FollowUI followUI)
    {
        this.followUI = followUI;
    }
}
