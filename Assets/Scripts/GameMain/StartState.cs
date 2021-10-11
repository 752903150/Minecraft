using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : ISceneState
{
    public StartState(SceneStateC c) : base(c)
    {
        this.StateName = "StartState";
    }

    public override void StateBegin()
    {
        Debug.Log("StartState");
    }

    public override void StateUpdate()
    {
        Debug.Log("StartState Update");
        m_Contorller.SetState(new MainState(m_Contorller),"MainScene");//³¡¾°Ìø×ª
    }

    public override void StateEnd()
    {
        Debug.Log("StartState End");
    }
}
