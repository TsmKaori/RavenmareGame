using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private int increaseMaxHealthCost = 40;
    private int increaseAttackDamageCost = 25;
    private int healthPotionCost = 5;

    void Start() {
        increaseMaxHealthUI.GetComponent<Text>().text += " (" + increaseMaxHealthCost + " gold)";
        increaseAttackDamageUI.GetComponent<Text>().text += " (" + increaseAttackDamageCost + " gold)";
        buyHealthPotionUI.GetComponent<Text>().text += " (" + healthPotionCost + " gold)";
    }

    public void increaseMaxHealth() {
        if(playerScript.takeGold(increaseMaxHealthCost)) {
            playerScript.increaseMaxHealth(10);
        }
    }

    public void increaseAttackDamage() {
        if(playerScript.takeGold(increaseAttackDamageCost)) {
            playerScript.increaseAttackDamage(1);
        }
    }

    public void buyHealthPotion() {
        if(playerScript.takeGold(healthPotionCost)) {
            playerScript.addHealthPotion();
        }
    }
}
