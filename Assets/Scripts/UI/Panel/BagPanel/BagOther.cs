using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BagOther : MonoBehaviour, IPointerClickHandler
{

    UnityEvent leftClick;
    UnityEvent rightClick;
    // Start is called before the first frame update

    public void Awake()
    {
        leftClick = new UnityEvent();
        rightClick = new UnityEvent();
    }
    public void SetButtonOnClickedBack(UnityAction actionLeft, UnityAction actionRight)
    {
        leftClick.AddListener(actionLeft);
        rightClick.AddListener(actionRight);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            leftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rightClick.Invoke();
    }
}
