using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenu : MonoBehaviour, IClick
{
    public void OnClickObject(Rigidbody2D obj)
    {
        while(obj.transform.position.y <= 4)
        {
            obj.gravityScale = -0.5f;
        }
        
        Debug.Log("it works");
    }
}
