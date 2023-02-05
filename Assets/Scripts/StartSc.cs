using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSc : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject[] texts;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
        texts[0].SetActive(true);
        StartCoroutine("Phrase1");
    }

    public IEnumerator Phrase1()
    {
        yield return new WaitForSeconds(3f);
        texts[1].SetActive(true);
        StartCoroutine("Phrase2");
    }

    public IEnumerator Phrase2()
    {
        yield return new WaitForSeconds(3f);
        texts[2].SetActive(true);
        StartCoroutine("Phrase3");
    }

    public IEnumerator Phrase3()
    {
        yield return new WaitForSeconds(3f);
        startScreen.GetComponent<Animation>().Play();
        foreach (GameObject phrase in texts)
        {
            phrase.GetComponent<Animation>().Play();
        }
        StartCoroutine("Phrase4");
    }

    public IEnumerator Phrase4()
    {
        yield return new WaitForSeconds(1f);
        startScreen.SetActive(false);
    }
}
