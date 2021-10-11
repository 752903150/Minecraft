using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof (Text))]
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the sceneS
            //SceneManager.LoadSceneAsync(SceneManager.loadedLevelName);
            //Application.LoadLevelAsync(Application.loadedLevelName);
        }
    }
}
