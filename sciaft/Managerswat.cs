using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Managerswat : MonoBehaviour
{
    private bool Tes;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Tes = true;
            this.GetComponent<Swatc>().enabled = true;
        }
    }
    
}
