using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GravityFunctions : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravityreset;
    public TextMeshProUGUI massDisplay;
    private float speedObj;
    // Update is called once per frame
    private void Awake()
    {
        gravityreset = false;
        speedObj = 3;
    }
    private void Update()
    {
        StopEffect();
        rb = GetComponent<MouseInput>().store;
        DisplayMass();
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
            rb.gravityScale = 0.5f;
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
            if(rb.mass > 1f)
            {
                rb.mass--;
            }
        }
    }
    public void DisplayMass()
    {
        if (rb != null)
        {
            massDisplay.text = "Mass:" + rb.mass;
        }
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speedObj, rb.velocity.y);
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2( speedObj, rb.velocity.y);
    }
}
