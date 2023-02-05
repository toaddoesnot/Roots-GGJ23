using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    public bool teleported;
    public bool teleportFin;

    public GameObject teleportSpot;

    private Rigidbody rb;
    public bool holding;

    //public float r_XAxis, r_YAxis, r_ZAxis;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (teleported)
        {
            this.transform.position = teleportSpot.transform.position;
            if(teleportFin is false)
            {
                teleported = false;
                StartCoroutine("FinTeleport");
                teleportFin = true;
            }
        }
    }

    private void OnMouseDown()
    {
        holding = true;
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
        if (holding)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
        
    }

    public void ChangePosition()
    {
        //transform.position = new Vector3(r_XAxis, r_YAxis, r_ZAxis);
    }

    public IEnumerator FinTeleport()
    {
        yield return 1f;
        teleportFin = false;
    }
}
