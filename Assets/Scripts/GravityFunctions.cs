using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFunctions : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravityreset = false;
    // Update is called once per frame
    private void Awake()
    {
        
    }
    private void Update()
    {
        StopEffect();
        rb = GetComponent<MouseInput>().store;
    }
    public void StartEffect()
    {
        if (rb != null)
        {
            rb.gravityScale = -0.5f;
            gravityreset = false;
        }
    }
    public void ResetEffect()
    {
        if (rb != null)
        {
            gravityreset = true;
            rb.gravityScale = 1f;
        }
    }
    private void StopEffect()
    {
        if (rb != null)
        {
            if (rb.gameObject.transform.position.y > 3f && gravityreset == false)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
    }
}
