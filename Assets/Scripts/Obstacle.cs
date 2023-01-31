using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool colliding;
    public InteractableObj inside;

    public void Start()
    {
        
    }

    public void Update()
    {
        if(inside != null)
        {
            if (colliding)
            {
                inside.teleported = true;
            }
            else
            {
                inside.teleported = false;
            }
        }

       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "drag")
        {
            inside = other.GetComponent<InteractableObj>();
            colliding = true;
            
        }
       
    }

    public void OnTriggerExit()
    {
        colliding = false;
    }
}
