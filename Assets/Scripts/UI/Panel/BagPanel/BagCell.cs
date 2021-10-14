using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagCell : MonoBehaviour,IPointerClickHandler
{
    Text NumText;
    Image ObjImage;
    UnityAction<int> ButtonOnLeftClickedToID;//左键按钮回调函数
    UnityAction<int> ButtonOnRightClickedToID;//右键按钮回调函数
    UnityAction<int> ButtonOnDoubleLeftClickedToID;//双击左键按钮回调函数

    private int id=0;
    private Button button;
    private int ObjNum = 0;//物品数量
    private ECube CurrCube;//当前方块类型

    public UnityEvent leftClick;
    public UnityEvent rightClick;
    public UnityEvent doubleLeftClick;

    private int click_flag = 0;
    private bool click_first = true;

    private float Interval = 0.15f;//双击间隔时间
    private float firstClicked = 0;
    private float secondClicked = 0;

    private void Start()
    {
        leftClick.AddListener(new UnityAction(ButtonOnLeftClicked));
        rightClick.AddListener(new UnityAction(ButtonOnRightClicked));
        doubleLeftClick.AddListener(new UnityAction(ButtonOnDoubleLeftClicked));

        button = GetComponent<Button>();
        /*if (button != null)
            button.onClick.AddListener(ButtonOnClicked);*/
        ObjImage = transform.GetChild(0).GetComponent<Image>();
        NumText = transform.GetChild(0).GetComponentInChildren<Text>();


        CurrCube = ECube.NORMAL;
        ObjNum = 0;
        NumText.text = "";
        ObjImage.sprite = PrefabsManagerSystem.GetCubeTextureFromID(ECube.NORMAL);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            click_flag++;//标志位增加,这里可以说的是

            if (!click_first) return;//说明上一轮还没有执行完

            click_first = false;
            Invoke("Timer", Interval);

        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick.Invoke();
        }
            
    }

    private void Timer()
    {
        if(click_flag>1)//如果还是true就说明点击了两次
        {
            doubleLeftClick.Invoke();
        }
        else
        {
            leftClick.Invoke();
        }
        click_first = true;
        click_flag = 0;//刷新标识
    }

    public void SetID(int ID)
    {
        id = ID;
    }
    public void SetButtonOnClickedBack(UnityAction<int> actionLeft, UnityAction<int> actionRight, UnityAction<int> actionDoubleLeft)
    {
        ButtonOnLeftClickedToID = actionLeft;
        ButtonOnRightClickedToID = actionRight;
        ButtonOnDoubleLeftClickedToID = actionDoubleLeft;
    }
    public void SetObj(ECube eCube,int num)
    {
        ObjNum = num;
        if (ObjNum == 0)
        {
            NumText.text = "";
            //CurrCube = ECube.NORMAL;
            eCube = ECube.NORMAL;
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
        if (eCube!=CurrCube)
        {
            PrefabsManagerSystem.BackCubeTexture(CurrCube, ObjImage.sprite);//回收资源
            ObjImage.sprite = PrefabsManagerSystem.GetCubeTextureFromID(eCube);
            CurrCube = eCube;
        }
    }
    public void SetNum(int num)
    {
        ObjNum = num;
        if (ObjNum == 0)
        {
            NumText.text = "";
            CurrCube = ECube.NORMAL;

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
            CurrCube = ECube.NORMAL;
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
    }
    public void AddNum(int num)
    {
        ObjNum+=num;
        if (ObjNum == 0)
        {
            NumText.text = "";
            CurrCube = ECube.NORMAL;
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
    }
    public void SubNum()
    {
        if (ObjNum == 0)
        {
            return;
        }
        ObjNum--;
        if (ObjNum == 0)
        {
            NumText.text = "";
            CurrCube = ECube.NORMAL;
        }
        else
        {
            NumText.text = ObjNum.ToString();
        }
        if (CurrCube == ECube.NORMAL)
        {
            PrefabsManagerSystem.BackCubeTexture(CurrCube, ObjImage.sprite);//回收资源
            ObjImage.sprite = PrefabsManagerSystem.GetCubeTextureFromID(ECube.NORMAL);
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
    void ButtonOnLeftClicked()
    {
        ButtonOnLeftClickedToID(id);
        //Debug.Log(id);
    }

    void ButtonOnRightClicked()
    {
        ButtonOnRightClickedToID(id);
        //Debug.Log(id);
    }
    void ButtonOnDoubleLeftClicked()
    {
        ButtonOnDoubleLeftClickedToID(id);
    }

}
