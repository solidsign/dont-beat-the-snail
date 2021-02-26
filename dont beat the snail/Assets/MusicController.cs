using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayTutor", 0.02f);
    }

    private void PlayTutor()
    {
        GetComponent<AudioController>().Play("tutor");
        GetComponent<AudioController>().Play("wind");
    }
    public void PlayDont()
    {
        GetComponent<AudioController>().Play("dont");
        GetComponent<AudioController>().Stop("tutor");
    }
}
