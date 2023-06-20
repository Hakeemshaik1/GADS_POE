using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D clicker;
    private CursorController control;
    private Camera cam;
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
        control.Mouse.Click.started += _ => StartClick();
        control.Mouse.Click.performed += _ => EndClick();
    }
    private void StartClick()
    {
        Changecursor(clicker);
    }
    private void EndClick()
    {
        Changecursor(cursor);
        DetectObject();
    }
    private void DetectObject()
    {
        Ray ray = cam.ScreenPointToRay(control.Mouse.Position.ReadValue<Vector2>());
        RaycastHit2D hits = Physics2D.GetRayIntersection(ray);
        if (hits.collider != null)
        {
            IClick click = hits.collider.GetComponent<IClick>();
            if (click != null) { click.OnClickObject(); }
            Debug.Log(hits.collider.tag);
        }
    }
    private void Changecursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto) ;
    }
}
