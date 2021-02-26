using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAbilityUI : MonoBehaviour
{
    private Image overlay;
    private Animator ability;
    private AbilityController abilityController;
    // Start is called before the first frame update
    void Start()
    {
        overlay = transform.GetChild(0).GetComponent<Image>();
        ability = transform.GetChild(1).GetComponent<Animator>();
        abilityController = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityController>();
        Invoke("StartSwitch", 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        overlay.fillAmount = (float)abilityController.abilities[0].cooldownTimer / (abilityController.abilities[0].Cooldown * 50);
    }

    public void Switch()
    {
        ability.SetTrigger(abilityController.abilities[0].animationName);
        transform.GetChild(2).GetComponent<ParticleSystem>().Play();
    }
    private void StartSwitch()
    {
        ability.SetTrigger(abilityController.abilities[0].animationName);
    }
}
