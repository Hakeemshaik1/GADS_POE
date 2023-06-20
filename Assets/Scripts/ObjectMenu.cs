using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenu : MonoBehaviour, IClick
{
    public void OnClickObject()
    {
        Destroy(gameObject);
        Debug.Log("it works");
    }
}
