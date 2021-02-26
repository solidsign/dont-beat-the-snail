using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnailController : Damagable
{

    public override void Damage(float damage)
    {
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        GameObject.FindObjectOfType<MusicController>().PlayDont();
        Invoke("func", 3f);
    }

    private void func()
    {
        SceneManager.LoadScene(1);
    }
}
