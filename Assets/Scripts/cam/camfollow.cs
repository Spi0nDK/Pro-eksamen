using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    //I det her script har vi variabler, og funktioner

    
    // her definere vi variabler og sætter transform til at være target etc.
    public Transform target;
    private Vector3 offset;

    //En Funktion som bliver kaldt i starten af scriptet og retunere ingen værdi grundet void
    void Start()
    {
//det her gør så kameraet følger efter target som har tagget player.
        target = GameObject.FindGameObjectWithTag("Player").transform;
        // Her udregner den positionen fra spilleren
        offset = transform.position - target.position;
    }

    // Her er der en funktion som opdateres hver frame og ikke retunere nogen værdi
    void Update()
    {
        //here opdatere den kamera positionen hvert frame
        transform.position = target.position + offset;
    }
}
