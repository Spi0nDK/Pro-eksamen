using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai : MonoBehaviour
{
//variabler, funktioner, datatyper, operatorer, if statements

    //referencer samt variabler

    public NavMeshAgent agent;
    public Transform player;
    public Transform player2;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    //Patrollere
    public Vector3 gaaPoint;
    bool GaaPointset;
    public float GaaPointAfstand;



    //angreber
    private float TidmellemAngreb = 0.75f;
    bool AlleredeAngrebet;

    //Stadier
    public float SynAfstand, AngrebAfstand;
    public bool PlayerISynAfstand, PlayerIAngrebAfstand;

//bliver kaldt lige meget hvad i starten (en funktion)
    private void Awake()
    {
//finder vores spiller. den finder automatisk player for hver enemy, så man ikke skal gøre det manuelt
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player2 = GameObject.FindGameObjectWithTag("Player").transform;
        //agent får dette component
        agent = GetComponent<NavMeshAgent>();
    }

//funktion som retunere ingen værdi og opdatere hver frame
    private void Update()
    {
        //tjekker om spiller er i afstand i synet og i angreb,
        // det den gør er at physics.checksphere er true hvis noget er inde for collider radiusen, hvilket er synafstand, hvor den så tager sin egen posion transform.position og layerd som det gælder for hvilket er spilleren
        PlayerISynAfstand = Physics.CheckSphere(transform.position, SynAfstand, whatIsPlayer);
        PlayerIAngrebAfstand = Physics.CheckSphere(transform.position, AngrebAfstand, whatIsPlayer);

//if statements, som styre hvilket mode den er i
        if (!PlayerISynAfstand && !PlayerIAngrebAfstand) Patrollere();
        if (PlayerISynAfstand && !PlayerIAngrebAfstand) JagtSpiller();
        if (PlayerIAngrebAfstand && PlayerISynAfstand) AngrebSpiller();

    }
    //funktion som ikke kan ses i inspectoren eller blive brugt i andre scripts grundet den er private, samt returner den ingen value grundet void
    private void Patrollere()
        {
            //ifstatement, hvis man ikke har sat gåpointet, så går den ud fra hvordan searchwalkpoint er defineret
        if (!GaaPointset) SearchWalkPoint();
//hvis der er sat, så bruger den det
        if (GaaPointset)
        agent.SetDestination(gaaPoint);
//Her udregner den afstanden til gaapointet.
        Vector3 AfstandTilGaaPoint= transform.position -gaaPoint;

        //naar man er naaet til gaapointet så er den false, hvor den automatisk søger efter en ny og looper
        if (AfstandTilGaaPoint.magnitude < 1f)
             GaaPointset=false;
        }
//en funktion 
private void SearchWalkPoint(){
//den giver en tilfældigt værdi for hvor de går inde for din gååpoint afstand
    float randomZ= Random.Range(-GaaPointAfstand, GaaPointAfstand);
    float randomX= Random.Range(-GaaPointAfstand, GaaPointAfstand);

    //definere gaapoint så den ved at gaa point skal være random i x og z aksen, hvor den er det samme i y aksen (hvor man så kan styre hvor den skal gå i unity inspektoren)
    gaaPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

//Tjekker om pointen for gaapoint overhovedet er på jorden via tagget, hvis den så er så aktivire den gaapoint
    if (Physics.Raycast(gaaPoint, -transform.up, 2f, whatIsGround))
    GaaPointset=true;
}

//jagt spiller funktion
    private void JagtSpiller()
        {
            //den vil sætte dens position til at "jagte" spiller positionen
        agent.SetDestination(player.position);
        agent.SetDestination(player2.position);
    }

//Angreb spiller funktion
    public void AngrebSpiller()
    {
        //stopper fjendens bevægelse
        agent.SetDestination(transform.position);
        //narr den har angrebet spilleren skal den vente i o.75 sekunder som tidmellemangreb er sat til
        Invoke("ResetAngreb", TidmellemAngreb);

        //goer så den kigger på spilleren, og faktisk drejer den rigtige vej
        transform.LookAt(player);
        //if statements
        if (player.position.x > transform.position.x)
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        transform.LookAt(player2);
        if (player2.position.x > transform.position.x)
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if (player2.position.x < transform.position.x)
        {
            transform.rotation = transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
//en funktion som  resetter angrebet, og gør så den ikke kan slå i 5 sekunder, hvordan efter stopper invoken og starter forfra
     void ResetAngreb()
        {
            TakeDamage(5);
            CancelInvoke();
        }


    //en funktion som gør så at spilleren mister livet ud fra dmg.
    void TakeDamage(int damage)
    {
        HealthPlayer.currentHealth -= damage;
       
    }
}
