using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("fun", 0.02f);
    }


    private void fun()
    {
        gameObject.GetComponent<AudioController>().Play("boss");
        gameObject.GetComponent<AudioController>().Play("wind");
    }
}
