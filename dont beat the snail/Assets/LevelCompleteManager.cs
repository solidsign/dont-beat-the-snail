using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    private bool end = false;
    private bool retry = false;
    private Transform canvas;
    public void ShowWinScreen()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        canvas.GetChild(0).gameObject.SetActive(false);
        canvas.GetChild(1).gameObject.SetActive(false);
        canvas.GetChild(2).gameObject.SetActive(false);
        canvas.GetChild(3).GetComponent<Animator>().SetTrigger("end");
        GameObject.FindObjectOfType<AudioController>().Stop("boss");
        GameObject.FindObjectOfType<AudioController>().Play("titor");
        end = true;
    }
    public void Retry()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        canvas.GetChild(0).gameObject.SetActive(false);
        canvas.GetChild(1).gameObject.SetActive(false);
        canvas.GetChild(2).gameObject.SetActive(false);
        canvas.GetChild(3).GetComponent<Animator>().SetTrigger("retry");
        GameObject.FindObjectOfType<AudioController>().Stop("boss");
        retry = true;
    }
    private void Update()
    {
        if (end)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (retry)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
