using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Lyd : MonoBehaviour
{
    //referere til vores audiosource
     public AudioSource AudioSource;
     //giver musikken en vardi som er 1
    private float musikLyd = 0.2f;


    //updatere hvert frame
        void Update()
    {
        //her vil vi opdatere lyden med den her musiklyd. Dette vil vi goere med vores slider
        AudioSource.volume = musikLyd;
    }

          // tager en vaedi fra vores slider, som saa er volume, saa hver gang vi rykker slideren kalder den den her funktion som giver vaerdien volume
       public void updateLyd(float volume)
    {
        // her goer vi saa vores baggrundsmusik = sliderens vaerdi
        musikLyd = volume;
    }
}
