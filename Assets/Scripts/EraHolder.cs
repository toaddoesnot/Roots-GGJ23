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

    void Update()
    {
        foreach(GameObject era in eras)
        {
            era.SetActive(false);
            eras[currentEra].SetActive(true);
        }
    }

    public void TimeTo()
    {
        anim.Play("RightRotation");

        StartCoroutine("ChangerTo");


    }

    public IEnumerator ChangerTo()
    {
        yield return new WaitForSeconds(0.75f);

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
        anim.Play("LeftRotation");

        StartCoroutine("ChangerBack");

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
