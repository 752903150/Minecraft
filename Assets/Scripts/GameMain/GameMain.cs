using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    SceneStateC sceneStateC;
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        sceneStateC = new SceneStateC();
        sceneStateC.SetState(new StartState(sceneStateC), "StartScene");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("GameUpdate");
        sceneStateC.Update();
    }
}
