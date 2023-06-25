using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GravityFunctions : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravityreset;
    // Update is called once per frame
    private void Awake()
    {
        gravityreset = false;
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
            rb.gravityScale = -1f;
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
    public void IncreaseMass()
    {
        if (rb != null)
        {
            rb.mass++;
        }
    }
    public void DecreaseMass()
    {
        if (rb != null)
        {
            rb.mass--;
        }
    }
}
