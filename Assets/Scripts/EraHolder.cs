using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraHolder : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    public GameObject[] eras;
    public int currentEra;

    public bool rotating;
    public float RotationSpeed = 4f;

    public Animation anim;
    public GameObject influCube;

    public Riddles ridSc;
    public bool locked;
    public GameObject ALock;
    public GameObject blocker;

    public bool resetEd;
    public EraManager eraSc;
    public GameObject floorCollider;


    void Update()
    {
        if (locked)
        {
            ALock.SetActive(true);
        }
        else
        {
            ALock.SetActive(false);
        }

        foreach(GameObject era in eras)
        {
            era.SetActive(false);
            eras[currentEra].SetActive(true);
        }

        if (currentEra is 2)
        {
            blocker.SetActive(true);
        }
        else
        {
            blocker.SetActive(false);
        }

        if (ridSc.neutralEra is 0)
        {
            if(resetEd is false)
            {
                StartCoroutine("Reset");
                resetEd = true;
            }
        }

    }

    public void TimeTo()
    {
        ridSc.butsActive = false;

        if (locked is false)
        {
            anim.Play("RightRotation");
            StartCoroutine("ChangerTo");
        }
    }

    public IEnumerator ChangerTo()
    {
        yield return new WaitForSeconds(0.75f);
        ridSc.butsActive = true;

        if (currentEra is 0)
        {
            currentEra = 1;
        }
        else
        {
            if (currentEra is 1)
            {
                currentEra = 2;
            }
            else
            {
                if (currentEra is 2)
                {
                    currentEra = 0;
                }
            }
        }

        
    }

    public void TimeBack()
    {
        ridSc.butsActive = false;

        if (locked is false)
        {
            anim.Play("LeftRotation");

            StartCoroutine("ChangerBack");
        }
            
         
    }

    public IEnumerator ChangerBack()
    {
        yield return new WaitForSeconds(0.75f);
        ridSc.butsActive = true;

        if (currentEra is 0)
        {
            currentEra = 2;
        }
        else
        {
            if (currentEra is 1)
            {
                currentEra = 0;
            }
            else
            {
                if (currentEra is 2)
                {
                    currentEra = 1;
                }
            }
        }

        
    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.75f);
        influCube.SetActive(true);
        eraSc.TV.SetActive(true);
        resetEd = false;
    }

}
