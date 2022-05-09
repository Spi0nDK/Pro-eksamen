using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFjende : MonoBehaviour
{
//her har vi 3 variabler, int hele tal, og definition samt en debug.
    public int maxHealth;
    public int currentHealth;
    public HealthBarFjende healthBarFjende;
    bool canangrebe = true;
    public GameController game;

    //en funktion som bliver kalde naar scriptet starter 1 gang grundet start og retunere ingen value grundet void, og start funtionen bliver kaldt foer update funktion
    void Start()
    {
        //saetter livet til at vaere til faeldigt mellem 26 og 76
        maxHealth = (Random.Range(25, 76));
        currentHealth = maxHealth;
        healthBarFjende.SetMaxHealth(maxHealth);
        
    }

    // Det her bliver kaldt n�r man sl�r. //En funktion som retunere ingen value grundet void og updatere hvert frame
    void Update()
    {
        healthBarFjende.SetHealth(currentHealth);
        // Det her if-statement tjekker om "canangreb" er true og at man trykker ned p� venstre musseknap. 0 st�r for venstre musseknap, 1 er h�jre musseknap og 2 er mussehjulet.
        if (canangrebe && Input.GetMouseButtonDown(0))
        {
            // Det her s�tter bool til false.
            canangrebe = false;
            // Invoke er en funktion som kalder en funktionen "Angreb" efter 0.75 sekunder.
            Invoke("Angreb", 0.75f);
        }

        if (currentHealth <= 0)
        {
            //den skal fjerne objektet
            Destroy(gameObject);
            game.SetButtonScore(gameObject.name, 1);
        }
    }

    // Det her bliver kaldt 0.75 sekunder efter man har trykket p� venstre musseknap, som g�r at man skader fjenderne.
    void Angreb()
    {
        // Den siger n�r man sl�r inde i console.
        Debug.Log("Attack called");
        // Det her s�tter bool til true.
        canangrebe = true;
        // Damage bliver fjernet fra fjendens hp.
        currentHealth -= Skade.Damage;
        // CancelInvoke bliver kaldt s� man ikke kan spamme sl� knappe.
        CancelInvoke();
    }

}

