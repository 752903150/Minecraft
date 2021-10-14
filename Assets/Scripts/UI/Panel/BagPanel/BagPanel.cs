using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class BagPanel : MonoBehaviour
{
    public UISystem uISystem;

    public MainBag mainBag;//������
    public FastBag fastBag;//���������
    public EquipmentBag equipmentBag;//װ��������
    public CompoundBag compoundBag;//�ϳ���
    public EndBag endBag;//�ϳɲ����

    public BagOther bagOther;//��������

    public GameObject followOBJ;
    FollowUI followUI;
    private void Start()
    {
        followUI = followOBJ.GetComponent<FollowUI>();
        mainBag.SetFollow(followUI);
        fastBag.SetFollow(followUI);
        equipmentBag.SetFollow(followUI);
        compoundBag.SetFollow(followUI);
        endBag.SetFollow(followUI);
        bagOther.SetButtonOnClickedBack(LeftClickedBackGround, RightClickedBackGround);
    }

    
    public int FastAddObj(ECube eCube, int num)
    {
        num = fastBag.FastAddObj(eCube, num);
        if(num==0)
        {
            return 0;
        }
        num = mainBag.FastAddObj(eCube, num);
        return num;
    }

    void LeftClickedBackGround()//�������
    {
        ECube eCube = followUI.GetCurrECube();
        int objnum = followUI.GetObjNum();
        followUI.CastOffAllObj();
        Debug.Log("����" + eCube + " " + objnum + "��");
    }

    void RightClickedBackGround()//�һ�����
    {
        ECube eCube = followUI.GetCurrECube();
        int objnum = followUI.GetObjNum();
        followUI.CastOffOneObj();
        Debug.Log("����" + eCube + " " + 1 + "��");
    }
}
