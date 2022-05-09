using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skade : MonoBehaviour
{

    // Vi har operatore, variabler, datatyper, if-statements, funktioner, return-types, class.

    // Her er vores funktioner, det er bool og int hvor bool er true eller false, og int er heltal
    public static int Damage;
    
    // Det her bliver kaldt når scenen starter som giver karakteren sin attack damage.
    void Start()
    {
        // Det her er et if statement som tjekker efter den karakter man har valgt.
        if (SceneSkift.AktivKriger == "Red")
        {
            // Det her er skaden fra den rødes class som bliver kaldt ind i scriptet og ganget med 2.
            Damage = SceneSkift.RedStats.Attack * 2;
        }
        else if (SceneSkift.AktivKriger == "Yellow")
        {
            Damage = SceneSkift.YellowStats.Attack * 2;
        }

    }

}