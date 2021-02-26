using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControllerUI : MonoBehaviour
{
    private PlayerHP playerhp;
    private Image hpBar;
    void Start()
    {
        Invoke("Initiate", 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = playerhp.hp / playerhp.maxHP;
    }

    private void Initiate()
    {
        hpBar = transform.GetComponent<Image>();
        playerhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
    }
}
