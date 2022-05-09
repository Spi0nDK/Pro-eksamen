using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSkift : MonoBehaviour
{

    // Vi har operatore, variabler, datatyper, if-statements, funktioner, return-types, class.

    // Public g�r s� vi kan bruge variablerne i unity inspekteren.
    // Det her er en variable som er et string s� en tekst.
    public static string AktivKriger = "Red";

    public class Stats
    {
        // Det her er vores tre variabler som bliver brugt i vores class, int er for heltal og float er for kommatal.
        public int Attack;
        public int Health;
        public float Speed;
        public Stats(int att, int hp, float spe) // Her bliver vores class kaldt med for skellige ting, s� som attack som er et heltal, hp som ogs� er heltal, men speed som er et float. 
        {
            // Her refererer vi vores variabler til vores stats i vores class.
            Attack = att;
            Health = hp;
            Speed = spe;
        }
    }

    // Her bliver der lavet to classes med forskellige stats til hver rider, s� den r�d rider har sine egne stats og den gule har sine egne. 
    public static Stats RedStats = new Stats(7, 4, 6);
    public static Stats YellowStats = new Stats(4, 9, 4);

    // Void g�r s� der ikke bliver returned nogen value.
    // Det den her kode g�r er at skifte scene n�r man trykker p� play inde i menuen hvor man kan v�lge karakter. Den viser ogs� i consollen hvilken man har valgt.
    // Den er public s� vi kan bruge den i unity inspekteren under Start knap.
    // Det her er en funktion.
    public void PlayGame()
    {
        if (AktivKriger == "Red")
        {
            Debug.Log("Red");
        }
        else if (AktivKriger == "Yellow")
        {
            Debug.Log("Yellow");
        }
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("you leaved");
        Application.Quit();
    }


   
    
    // Det her g�r s� karakteren skifter n�r man trykker p� pilen under "Character Selection" menuen.
    public void ChangeCharacter()
    {
        if (AktivKriger == "Red")
        {
            AktivKriger = "Yellow";
        }
        else if (AktivKriger == "Yellow")
        {
            AktivKriger = "Red";
        }
    }

}
