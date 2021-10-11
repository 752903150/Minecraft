using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainState : ISceneState
{
    public MainState(SceneStateC c):base(c)
    {
        this.StateName = "MainState";
    }

    public override void StateBegin()
    {
        Debug.Log("MainState");
    }

    public override void StateUpdate()
    {
        Debug.Log("MainState Update");
    }

    public override void StateEnd()
    {
        Debug.Log("MainState End");
    }
}
