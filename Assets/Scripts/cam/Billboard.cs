using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //her har vi en variable, og en funktion.



    //jeg har gjort så cam er en public variable så jeg kan drag and drop mit kamera i unity inspectoren
    public Transform cam;

    
    void Update()
    {
        //Transform gør så at kameraet bliver positioneret
        //LookAt har en lille kode som gør at den skal gøre at kiv baren hele tiden
        transform.LookAt(transform.position + cam.forward);
    }
}
