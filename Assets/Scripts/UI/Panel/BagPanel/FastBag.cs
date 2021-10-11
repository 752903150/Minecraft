using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBag : MonoBehaviour
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
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("按下了左Ctrl键");
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("按下了左Shift键");
        }
        else
        {
            Debug.Log("没有按下任何键");
            bagCells[id].AddNum();
        }
    }
    public void SetFollow(FollowUI followUI)
    {
        this.followUI = followUI;
    }
}
