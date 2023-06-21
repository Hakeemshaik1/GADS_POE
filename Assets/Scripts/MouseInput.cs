using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D clicker;
    private CursorController control;
    private Camera cam;
    private bool gravityReset = false;
    private Rigidbody2D store;
    private void Awake()
    {
        control = new CursorController();
        Changecursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        cam = Camera.main;
    }
    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
    private void Start()
    {
        control.Mouse.Click.performed += _ => EndClick();
    }
    private void Update()
    {
        StopEffect(store);
    }
    private void EndClick()
    {
        DetectObject();
    }
    private void DetectObject()
    {
        Ray ray = cam.ScreenPointToRay(control.Mouse.Position.ReadValue<Vector2>());
        RaycastHit2D hits = Physics2D.GetRayIntersection(ray);
        if (hits.collider != null)
        {
            //OnClickObject(hits.rigidbody);
            StartEffect(hits.rigidbody);
            store = hits.rigidbody;
        }
    }
    public void StartEffect(Rigidbody2D obj)
    {
        obj.gravityScale = -0.5f;
        gravityReset = true;
    }
    private void StopEffect(Rigidbody2D scale)
    {
        if (scale != null)
        {
            if (scale.gameObject.transform.position.y > 3f && gravityReset == true)
            {
                scale.velocity = Vector2.zero;
                scale.gravityScale = 0f;
                //gravityReset = false;
            }
        }
    }
    private void Changecursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto) ;
    }
}
