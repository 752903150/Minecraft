using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BagCell : MonoBehaviour
{
    Text NumText;
    Image ObjImage;
    UnityAction<int> ButtonOnClickedToID;//按钮回调函数
    private int id=0;
    private Button button;
    private int ObjNum = 0;//物品数量
    private ECube CurrCube;//当前方块类型


    public void SetID(int ID)
    {
        id = ID;
    }
    public void SetButtonOnClickedBack(UnityAction<int> action)
    {
        ButtonOnClickedToID = action;
    }
    public void SetObj(ECube eCube,int num)
    {
        if(eCube!=CurrCube)
        {
            PrefabsManagerSystem.BackCubeTexture(CurrCube, ObjImage.sprite);
            ObjImage.sprite = PrefabsManagerSystem.GetCubeTextureFromID(eCube);
            CurrCube = eCube;
        }
        ObjNum = num;
        if (ObjNum == 0)
        {
            NumText.text = "";
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
    }
    public void SetNum(int num)
    {
        ObjNum = num;
        if (ObjNum == 0)
        {
            NumText.text = "";
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
    }
    public void AddNum()
    {
        ObjNum++;
        if (ObjNum == 0)
        {
            NumText.text = "";
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
    }
    public void SubNum()
    {
        ObjNum--;
        if(ObjNum==0)
        {
            NumText.text = "";
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
    }

    public ECube GetCurrECube()
    {
        return CurrCube;
    }

    public int GetObjNum()
    {
        return ObjNum;
    }
    private void Start()
    {

        button = GetComponent<Button>();
        if(button!=null)
            button.onClick.AddListener(ButtonOnClicked);
        ObjImage = transform.GetChild(0).GetComponent<Image>();
        NumText = transform.GetChild(0).GetComponentInChildren<Text>();
        

        CurrCube = ECube.NORMAL;
        ObjNum = 0;
        NumText.text = "";
        ObjImage.sprite = PrefabsManagerSystem.GetCubeTextureFromID(ECube.NORMAL);

    }
    void ButtonOnClicked()
    {
        ButtonOnClickedToID(id);
        //Debug.Log(id);
    }
}
