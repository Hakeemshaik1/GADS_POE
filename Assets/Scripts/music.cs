using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public static music instance;

    void Awake()
    {
        
    DontDestroyOnLoad(this.gameObject);
        
    }
}