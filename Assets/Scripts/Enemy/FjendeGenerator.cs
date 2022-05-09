using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FjendeGenerator : MonoBehaviour
{
//i dette scrip har vi varibler, forskellige datayper, operatorer, funktioner og ifstatements

    // Her er vores variabler som skal bruges til at s�tte hvilke goblins der skal spawn. 
    
    public GameObject Goblin;
    public GameObject Goblin2;
    public GameObject Goblin3;
    public string[] GoblinChoose = { "Pink", "Red", "Green" }; // Det er et array som v�lger hvilken en af de tre goblins der skal spawn.
    public int RandomGoblin; // Det er et integer (Heltal)

// funktion som bliver kaldt i starten og retunere ingen value
    void Start()
    {
        Invoke("SpawnGoblin", 3f); // Invoke g�r s� den k�rer "void SpawnGoblin" 3 sekunder efter spillet er startet.
    }

//en funktion
    private void  SpawnGoblin()
    {
        int i = 0;
        while (i == 0) // Et while loop som k�rer n�r funktionen SpawnGoblin bliver k�rt.
        {
            i++; // Det er s� while loopet ikke k�rer hele tiden og crasher programmet, s� der er styr p� det.
            RandomGoblin = (Random.Range(0, 3)); // Det her s�tter vores integer til et tilf�ldigt tal som bliver brugt til at bestemme vores goblin.

            if (HealthPlayer.currentHealth > 0) // F�r den spawner en goblin skal den finde ud af om spilleren har noget hp f�r den vil k�re det.
            {
                if (GoblinChoose[RandomGoblin] == "Green") // Her er det hvis vores tilf�ldige tal og array er "Green" vil den spawn den gr�nne goblin.
                {
                    Instantiate(Goblin); // Det er s� den laver en kopi af vores gameobject som er defineret l�ngere oppe.
                }
                else if (GoblinChoose[RandomGoblin] == "Pink")
                {
                    Instantiate(Goblin2);
                }
                else if (GoblinChoose[RandomGoblin] == "Red")
                {
                    Instantiate(Goblin3);
                }
            }
        }
       
        CancelInvoke(); // Det stopper funktionen med at k�re i loop. 
        Invoke("SpawnGoblin", 3f); // Det her g�r s� funktionen bliver k�rt efter 3 sekunder igen. 
    }
}