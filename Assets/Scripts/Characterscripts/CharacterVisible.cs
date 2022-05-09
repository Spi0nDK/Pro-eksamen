using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisible : MonoBehaviour
{
//variable, funktion og if statement



// static, det gør så varaiblem kan blive brugt i andre scripts og at den ikke laver flere instancer af variablen.
// her laver vi en gameobject variable som er defineret som karakter
     static GameObject Karakter;

//Start funktion, som bliver kaldt først og i starten af scriptet.
    void Start()
    {
         //if statement, hvis man er rød så bliver yellow gjort nonactive
        if (SceneSkift.AktivKriger == "Red")
        {
             //her finder den yellow
            Karakter = GameObject.Find("CharacterYellow");
        }
        //if statement, hvis man er gul så bliver red gjort nonactive
        else if (SceneSkift.AktivKriger == "Yellow")
        {
     //her finder den red
            Karakter = GameObject.Find("CharacterRed");
        }
              //gør karekteren nonactive
        Karakter.SetActive(false);
    }
}
