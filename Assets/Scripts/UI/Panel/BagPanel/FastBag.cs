using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBag : MonoBehaviour
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
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("��������Ctrl��");
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("��������Shift��");
        }
        else
        {
            Debug.Log("û�а����κμ�");
            bagCells[id].AddNum();
        }
    }
    public void SetFollow(FollowUI followUI)
    {
        this.followUI = followUI;
    }
}
