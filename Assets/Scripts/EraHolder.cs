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

    public GameObject[] colliders; //if collider[1].GetComponent<script>().slot full is true then influcube is not active
    public GameObject influCube;
    public int DeadSpot1;
    public int DeadSpot2;
    public int DeadSpot3;
    public int ExtraDeath;

    public Riddles ridSc;
    public bool locked;
    public GameObject ALock;
    public GameObject blocker;

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

    }

    public void TimeTo()
    {
        if(locked is false)
        {
            anim.Play("RightRotation");
            StartCoroutine("ChangerTo");
        }
    }

    public IEnumerator ChangerTo()
    {
        yield return new WaitForSeconds(0.75f);

        if (currentEra is 0)
        {
            currentEra = 1;
            if (colliders[DeadSpot1].GetComponent<Snapper>().slotFull)
            {
                influCube.SetActive(false);
            }
        }
        else
        {
            if (currentEra is 1)
            {
                currentEra = 2;
                if (colliders[DeadSpot2].GetComponent<Snapper>().slotFull || colliders[ExtraDeath].GetComponent<Snapper>().slotFull)
                {
                    influCube.SetActive(false);
                }

            }
            else
            {
                if (currentEra is 2)
                {
                    currentEra = 0;
                    if (colliders[DeadSpot3].GetComponent<Snapper>().slotFull)
                    {
                        influCube.SetActive(false);
                    }
                }
            }
        }
    }

    public void TimeBack()
    {
        if (locked is false)
        {
            anim.Play("LeftRotation");

            StartCoroutine("ChangerBack");
        }
            

    }

    public IEnumerator ChangerBack()
    {
        yield return new WaitForSeconds(0.75f);

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

    

}
