using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BagPanel : MonoBehaviour
{
    public UISystem uISystem;

    public MainBag mainBag;//������
    public FastBag fastBag;//���������
    public EquipmentBag equipmentBag;//װ��������
    public CompoundBag compoundBag;//�ϳ���
    public EndBag endBag;//�ϳɲ����

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
        Debug.Log("�ɹ�����");
    }
}
