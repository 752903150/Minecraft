using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] RectTransform rectTransform;
    
    [SerializeField] Camera _camera; 
    [SerializeField] RectTransform canvasRectTransform;
    Vector2 pos;
    bool state = false;

    [SerializeField] Text NumText;
    [SerializeField] Image ObjImage;
    private int ObjNum = 0;//物品数量
    private ECube CurrCube;//当前方块类型
    private void Start()
    {
        NumText.text = "";
        CurrCube = ECube.NORMAL;
        ObjImage = transform.GetChild(0).GetComponent<Image>();
        NumText = transform.GetChild(0).GetComponentInChildren<Text>();
        //EventManagerSystem.Instance.Add();
    }
    private void Update()
    {
        FollowMouseMove();
        //transform.localPosition = Input.mousePosition;
    }

    public void FollowMouseMove()
    {
        //worldCamera:1.screenSpace-Camera 
        // canvas.GetComponent<Camera>() 1.ScreenSpace -Overlay 
        if (RenderMode.ScreenSpaceCamera == canvas.renderMode)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, canvas.worldCamera, out pos);
        }
        else if (RenderMode.ScreenSpaceOverlay == canvas.renderMode)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, _camera, out pos);


        }
        else
        {
            Debug.Log("请选择正确的相机模式!");
        }

        rectTransform.anchoredPosition = pos;
    } 

    public void SetObj(ECube eCube, int num)
    {
        if (eCube != CurrCube)
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
        if (ObjNum == 0)
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

    public void SetActivity(bool flag)
    {
        gameObject.SetActive(flag);
    }
}
