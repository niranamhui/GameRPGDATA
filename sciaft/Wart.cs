using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wart : MonoBehaviour
{
    
    public Text Pwark;

      private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pwark.text = " Press  P For Wart";
        }
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.P))
         {
            Destroy(this.gameObject);
        }
       
        //ui.SetActive(true);
    }
    
}
