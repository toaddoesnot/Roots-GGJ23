using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    public bool teleported;
    public GameObject teleportSpot;

    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (teleported)
        {
            this.transform.position = teleportSpot.transform.position;
            
            //teleported = false;
        }
    }

    private void OnMouseDown()
    {
        
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseUp()
    {
        
    }

    private void OnMouseEnter()
    {
        print("I'm in");
    }

    private void OnMouseExit()
    {
        
    }
}
