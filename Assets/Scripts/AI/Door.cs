using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool unlocked;
    public bool angry;
    public bool strong;
    public Menu thing;
    public GameObject reset;

    public void Start()
    {
        thing = FindAnyObjectByType<Menu>();
        unlocked = thing.unlocked.isOn;
        angry = thing.angry.isOn;
        strong = thing.strong.isOn;
        Invoke("Reset", 3f);
    }

    public void Open()
    {
        if(unlocked)
        {
            if (angry)
            {
                if (strong)
                {
                    GetComponent<Animator>().Play("UnlockAngryStrong");
                    Invoke("End", 1f);
                }
                else
                {
                    GetComponent<Animator>().Play("UnlockAngryWeak");
                    Invoke("End", 1f);
                }
            }
            else
            {
                if (strong)
                {
                    GetComponent<Animator>().Play("UnlockNoAngryStrong");
                    Invoke("End", 1f);
                }
                else
                {
                    GetComponent<Animator>().Play("UnlockNoAngryWeak");
                    Invoke("End", 1f);
                }
            }
        }
        else
        {
            if (angry)
            {
                if (strong)
                {
                    GetComponent<Animator>().Play("LockAngryStrong");
                    Invoke("End", 1f);
                }
                else
                {
                    GetComponent<Animator>().Play("LockAngryWeak");
                    Invoke("End", 1f);
                }
            }
            else
            {
                if (strong)
                {
                    GetComponent<Animator>().Play("LockNoAngryStrong");
                    Invoke("End", 1f);
                }
                else
                {
                    GetComponent<Animator>().Play("LockNoAngryWeak");
                    Invoke("End", 1f);
                }
            }
        }
    }

    void End()
    {
        GetComponent<Animator>().enabled = false;
    }

    void Reset()
    {
        reset.SetActive(true);
        reset.GetComponent<Button>().onClick.AddListener(thing.Load);
    }
}
