using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Texture2D cursor;
    public GameObject panel;
    private CursorController control;
    private Camera cam;
    public Rigidbody2D store;
    private void Awake()
    {
        control = new CursorController();
        Changecursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        cam = Camera.main;
        panel.SetActive(false);
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
    public void DetectObject()
    {
        Ray ray = cam.ScreenPointToRay(control.Mouse.Position.ReadValue<Vector2>());
        RaycastHit2D hits = Physics2D.GetRayIntersection(ray);
        if (hits.collider != null)
        {
            if(hits.collider.CompareTag("Object"))
            {
                store = hits.rigidbody;
                panel.SetActive(true);
            } 
        }
    }
    public void ClearObject()
    {
        store = null;
        panel.SetActive(false);
    }
    private void Changecursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto) ;
    }
}
