using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFunctions : MonoBehaviour
{
    private Rigidbody2D rb;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<MouseInput>().store;
    }
    private void Update()
    {
        StopEffect();
    }
    public void StartEffect()
    {
        rb.gravityScale = -0.5f;
    }
    public void ResetEffect()
    {
        rb.gravityScale = 1f;
    }
    private void StopEffect()
    {
        if (rb != null)
        {
            if (rb.gameObject.transform.position.y > 3f)
            {
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
    }
}
