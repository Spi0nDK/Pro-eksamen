using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// I det her script har vi Variabler, Operatorer og Funktioner 
public class HealthBar : MonoBehaviour
{

    //Her har vi defineret nogle variabler til vores slider på liv baren
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Her har vores Metode som i det tilfælde er vores maxhealth 
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // Her har vi vores anden metode som er Sethealth som er med til at blive defineret af vores variabler og SetMaxHealth i HealthPlayer scriptet
    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
