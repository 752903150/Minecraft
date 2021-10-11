using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObj : MonoBehaviour
{
    public MediaSystem mediaSystem;//中介者系统
    // Start is called before the first frame update
    void Start()
    {
        mediaSystem.SetTasksNum(100);
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        for(int i=0;i<100;i++)
        {
            yield return new WaitForSeconds(0.1f);
            mediaSystem.AddTasksNum(1);
        }
    }
}
