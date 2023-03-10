using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EraManager : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject Rcollider;
    public GameObject LCollider;
    public GameObject XCollider;
    public GameObject OCollider;
    public GameObject X1Collider;
    public GameObject LFloor;

    public GameObject TV;
    public Riddles ridSc;

    public GameObject winText;
    public GameObject buttons;
    public bool lastIsBack;

    public bool firWin;
    public bool sndWin;
    public bool thrdWin;


    public void Update()
    {
        if (rooms[0].GetComponent<EraHolder>().currentEra is 2)
        {
            if (rooms[0].GetComponent<EraHolder>().influCube.activeInHierarchy)
            {
                if (TV.activeInHierarchy && rooms[0].GetComponent<EraHolder>().locked is false  && lastIsBack is false || TV.activeInHierarchy && rooms[0].GetComponent<EraHolder>().locked is true)
                {
                    rooms[0].GetComponent<EraHolder>().locked = true;
                }
            }
        }
        else
        {
            rooms[0].GetComponent<EraHolder>().locked = false;
        }

        if (rooms[2].GetComponent<EraHolder>().currentEra is 2)
        {
            if (rooms[1].GetComponent<EraHolder>().influCube.activeInHierarchy)
            {
                if(rooms[0].GetComponent<EraHolder>().locked is true)
                {
                    rooms[2].GetComponent<EraHolder>().locked = true;
                }
            }
        }
        else
        {
            rooms[2].GetComponent<EraHolder>().locked = false;
        }

        if (rooms[1].GetComponent<EraHolder>().currentEra is 2 && rooms[2].GetComponent<EraHolder>().locked && rooms[0].GetComponent<EraHolder>().locked && rooms[1].GetComponent<EraHolder>().influCube.activeInHierarchy)
        {
            rooms[1].GetComponent<EraHolder>().locked = true;
            winText.SetActive(true);
            StartCoroutine("Replay");
            buttons.SetActive(false);
        }
    }

    public void ButtonTo()
    {
        ridSc.neutralEra++;
        lastIsBack = false;

        foreach (GameObject room in rooms)
        {
            room.GetComponent<EraHolder>().TimeTo();
        }

        if (rooms[2].GetComponent<EraHolder>().currentEra is 2)
        {
            StartCoroutine("LineOne");
            
            //print("HERE");
        }

        if (rooms[2].GetComponent<EraHolder>().currentEra is 0) 
        {
            StartCoroutine("LineTwo");
            
        }

        if (rooms[2].GetComponent<EraHolder>().currentEra is 1)
        {
            StartCoroutine("LineThree");
        }

        if (rooms[1].GetComponent<EraHolder>().currentEra is 1)
        {
            StartCoroutine("LineLast");
        }


    }

    public void ButtonBack()
    {
        ridSc.neutralEra--;
        lastIsBack = true;

        foreach (GameObject room in rooms)
        {
            room.GetComponent<EraHolder>().TimeBack();
        }

        if (rooms[1].GetComponent<EraHolder>().currentEra is 0 && rooms[0].GetComponent<EraHolder>().locked)
        {
            rooms[0].GetComponent<EraHolder>().locked = false;
            rooms[0].GetComponent<EraHolder>().anim.Play("LeftRotation");
            rooms[0].GetComponent<EraHolder>().StartCoroutine("ChangerBack");
            
            
        }

        if (rooms[1].GetComponent<EraHolder>().currentEra is 0)
        {
            if (firWin)
            {
                StartCoroutine("TVBack");
            }
        }


        if (rooms[1].GetComponent<EraHolder>().currentEra is 1 && rooms[2].GetComponent<EraHolder>().locked)
        {
            rooms[2].GetComponent<EraHolder>().locked = false;
            rooms[2].GetComponent<EraHolder>().anim.Play("LeftRotation");
            rooms[2].GetComponent<EraHolder>().StartCoroutine("ChangerBack");
        }

        if (rooms[0].GetComponent<EraHolder>().currentEra is 1)
        {
            StartCoroutine("TVBack");
            
        }

        if (rooms[1].GetComponent<EraHolder>().currentEra is 1 || rooms[1].GetComponent<EraHolder>().currentEra is 2)
        {
            StartCoroutine("OBack");
        }
    }

    public IEnumerator LineOne()
    {
        yield return new WaitForSeconds(0.75f);

        if (X1Collider.GetComponent<Snapper>().slotFull is false)
        {
            rooms[0].GetComponent<EraHolder>().influCube.SetActive(false);
        }

        if (rooms[1].GetComponent<EraHolder>().influCube.activeInHierarchy && rooms[0].GetComponent<EraHolder>().influCube.activeInHierarchy)
        {
            firWin = true;
        }

    }


    public IEnumerator LineTwo()
    {
        yield return new WaitForSeconds(0.75f);

        if (Rcollider.GetComponent<Snapper>().slotFull is false)
        {
            rooms[0].GetComponent<EraHolder>().influCube.SetActive(false);
        }
        if (rooms[0].GetComponent<EraHolder>().influCube.activeInHierarchy is false)
        {
            //rooms[1].GetComponent<EraHolder>().influCube.SetActive(false); - fallacy
        }
        if (LCollider.GetComponent<Snapper>().slotFull is true || LFloor.GetComponent<Snapper>().slotFull is true)
        {
            TV.SetActive(false);
        }

        if (rooms[1].GetComponent<EraHolder>().influCube.activeInHierarchy && rooms[0].GetComponent<EraHolder>().influCube.activeInHierarchy && TV.activeInHierarchy)
        {
            sndWin = true;
        }
    }

    public IEnumerator LineThree()
    {
        yield return new WaitForSeconds(0.75f);

        if (Rcollider.GetComponent<Snapper>().slotFull is false || OCollider.GetComponent<Snapper>().slotFull is true)
        {
            rooms[1].GetComponent<EraHolder>().influCube.SetActive(false);
        }
    }

    public IEnumerator LineLast()
    {
        yield return new WaitForSeconds(0.75f);

        if (OCollider.GetComponent<Snapper>().slotFull is false)
        {
            rooms[1].GetComponent<EraHolder>().influCube.SetActive(false);
        }
    }

    public IEnumerator TVBack()
    {
        yield return new WaitForSeconds(0.75f);

        rooms[0].GetComponent<EraHolder>().influCube.SetActive(true);
        rooms[1].GetComponent<EraHolder>().influCube.SetActive(true);
        rooms[2].GetComponent<EraHolder>().influCube.SetActive(true);

        if (ridSc.neutralEra > 0)
        {
            TV.SetActive(true);
        }
        else
        {
            TV.SetActive(false);
        }
    }

    public IEnumerator OBack()
    {
        yield return new WaitForSeconds(0.75f);

        rooms[1].GetComponent<EraHolder>().influCube.SetActive(true);
    }

    public IEnumerator Replay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
