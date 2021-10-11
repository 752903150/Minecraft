using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BagPanel : MonoBehaviour
{
    public UISystem uISystem;

    public MainBag mainBag;//主背包
    public FastBag fastBag;//快捷栏背包
    public EquipmentBag equipmentBag;//装备栏背包
    public CompoundBag compoundBag;//合成栏
    public EndBag endBag;//合成产物表

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
        Debug.Log("成功设置");
    }
}
