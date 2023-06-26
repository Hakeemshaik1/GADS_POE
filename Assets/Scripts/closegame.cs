using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closegame : MonoBehaviour
{
    public void CloseGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
