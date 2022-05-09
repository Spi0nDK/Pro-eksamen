using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beholdmusik : MonoBehaviour
{
    //paa den 1 frame kalder den scriptet
    void Awake()
    {
        //den skal ikke destroere vores object naar en ny scene loader
        DontDestroyOnLoad(transform.gameObject);
    }
}
