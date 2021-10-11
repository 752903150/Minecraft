using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHide : MonoBehaviour
{
    public void Show()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
    public void Hide()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}
