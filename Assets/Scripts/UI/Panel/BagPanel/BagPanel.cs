using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class BagPanel : MonoBehaviour
{
    public UISystem uISystem;

    public MainBag mainBag;//主背包
    public FastBag fastBag;//快捷栏背包
    public EquipmentBag equipmentBag;//装备栏背包
    public CompoundBag compoundBag;//合成栏
    public EndBag endBag;//合成产物表

    public BagOther bagOther;//背包背景

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

    void LeftClickedBackGround()//左击背景
    {
        ECube eCube = followUI.GetCurrECube();
        int objnum = followUI.GetObjNum();
        followUI.CastOffAllObj();
        Debug.Log("丢弃" + eCube + " " + objnum + "个");
    }

    void RightClickedBackGround()//右击背景
    {
        ECube eCube = followUI.GetCurrECube();
        int objnum = followUI.GetObjNum();
        followUI.CastOffOneObj();
        Debug.Log("丢弃" + eCube + " " + 1 + "个");
    }
}
