using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Player playerScript;
    [SerializeField]
    private GameObject increaseMaxHealthUI;
    [SerializeField]
    private GameObject increaseAttackDamageUI;
    [SerializeField]
    private GameObject buyHealthPotionUI;
    [SerializeField]
    private AudioSource buySound;

    private int increaseMaxHealthCost = 100;
    private int increaseAttackDamageCost = 60;
    private int healthPotionCost = 10;

    void Start() {
        increaseMaxHealthUI.GetComponent<TextMeshProUGUI>().text += " (" + increaseMaxHealthCost + " gold)";
        increaseAttackDamageUI.GetComponent<TextMeshProUGUI>().text += " (" + increaseAttackDamageCost + " gold)";
        buyHealthPotionUI.GetComponent<TextMeshProUGUI>().text += " (" + healthPotionCost + " gold)";
    }

    public void increaseMaxHealth() {
        buySound.Play();
        if(playerScript.takeGold(increaseMaxHealthCost)) {
            playerScript.increaseMaxHealth(10);
        }
    }

    public void increaseAttackDamage() {
        buySound.Play();
        if(playerScript.takeGold(increaseAttackDamageCost)) {
            playerScript.increaseAttackDamage(1);
        }
    }

    public void buyHealthPotion() {
        buySound.Play();
        if(playerScript.takeGold(healthPotionCost)) {
            playerScript.addHealthPotion();
        }
    }
}
