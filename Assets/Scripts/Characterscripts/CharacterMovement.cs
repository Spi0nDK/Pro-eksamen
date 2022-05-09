using System;
using UnityEngine;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    //I dette script har vi funktioner, operatører, forskellige datatyper, varibler og ifstatements


    //reffere tol character controlelr og definition
    public CharacterController controller;

//2 float varabler, hvor vi giver gravity til spillern, de private så de ikke kan ændrers i unity inspektoren
    private float speed;
    private float gravity = -9.81f;

   //definition af vector3
    Vector3 velocity;
//definition af animator og float af fart
    public Animator animation;
    public float Fart = 0;

//2 floats mere
    float turnSmoothVelocity;
   float turnSmoothTime = 0.1f;

    // Update is called once per frame
//Start funktion, som bliver kaldt som det første og retunere ingen værdi grundet void
    void Start()
    {
        //if statement, hvis man er krigeren rød, så får man den røde krigers stats når man trykker på karakteren red og det omvendte med den gule
        if (SceneSkift.AktivKriger == "Red")
        {
            speed = SceneSkift.RedStats.Speed;
        }
        else if (SceneSkift.AktivKriger == "Yellow")
        {
            speed = SceneSkift.YellowStats.Speed;
        }
    }
//Update funktionen, som kaldes hvert frame efter start og retuner ingen value.
    void Update()
    {

        //gravity, som siger 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 

        //walk
        //sætter voes movement op i x og z  aksen, hvor vi får det rå input.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Vi store vores "direction", hvor vi sætter  x aksen til horizontal, y til 0 siden vi ikke skal bevæge os i yaksen, og z til vertical, hvor vi så normalizer det så når vi holder 2 knapper ned at vi går diagonalt og ikke bevæger os hurtigere
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

//hvis vores direction vector er større end 0.1 jamen så får vi input til at bevæge os
//if statement
        if (direction.magnitude >= 0.1f)
        {
            
          
            //Dette er en funktion som bruger vores controller på karakteren
            //den giver så inputtet som er vores direction, vores hastighed og så time.deltatime for at det er framrate uafhængigt
            controller.Move(direction * speed * Time.deltaTime);



            Fart = 0.1f;


        }

        else if (direction.magnitude <= 0.1f)
        {
            Fart = 0;
        }

        animation.SetFloat("Fart", Mathf.Abs(Fart));

        // Rotation, når vi trykker på an af disse keys går den i gennem it ifstatement som gør at spilleren rotere i y aksen
        if (Input.GetKeyDown("a"))
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

    }
}