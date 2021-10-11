using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateC
{
    private ISceneState m_State;
    bool isBegin = false;

    public SceneStateC() { }

    public void SetState(ISceneState state,string LoadSceneName)
    {
        isBegin = false;
        LoadScene(LoadSceneName);
        if(m_State!=null)
        {
            m_State.StateEnd();
        }
        m_State = state;
    }

    private void LoadScene(string loadSceneName)
    {
        if(loadSceneName == null||loadSceneName.Length==0)
        {
            return;
        }
        SceneManager.LoadScene(loadSceneName);
    }

    public void Update()
    {
        if(!isBegin)
        {
            m_State.StateBegin();
            isBegin = true;
        }
        m_State.StateUpdate();
    }
}
