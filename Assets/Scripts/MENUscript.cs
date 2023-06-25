using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUscript : MonoBehaviour
{
    public string sceneToLoad;

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
