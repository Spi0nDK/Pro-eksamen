using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthPlayer : MonoBehaviour
{
    // I det her script har vi Variabler, Operatorer, Funktioner og If statements 

    // Variabler
    public int maxHealth;
    public static int currentHealth;
    //referencer til vores healthbar
    public HealthBar healthBar;

    // Det her kode bliver brugt når spillet starter
    void Start()
    {

        if (SceneSkift.AktivKriger == "Red")
        {
            maxHealth = SceneSkift.RedStats.Health * 10;
        }
        else if (SceneSkift.AktivKriger == "Yellow")
        {
            maxHealth = SceneSkift.YellowStats.Health * 10;
        }
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // det er en function som returener ingen value og ipdatere hvert frame

    void Update()
    {
        //hvis spillerens liv er 0 eller under, så skal den skifte over til hovedmenu
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(0);
            SceneSkift.AktivKriger = "Red";
        }
        healthBar.SetHealth(currentHealth);
    }
}
