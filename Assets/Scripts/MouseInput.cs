using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D clicker;
    private CursorController control;
    private Camera cam;
    public Rigidbody2D store;
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
            store = hits.rigidbody;
        }
    }
    private void Changecursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto) ;
    }
}
