using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{
    //public GameObject ui;
    public GameObject Player;
    public Transform tpLoc;

    private void Start()
    {
       // ui.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //ui.SetActive(true);
        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.P))
        {
            Player.transform.position = tpLoc.transform.position;

            Debug.Log("OK");
        }
    }

    private void OnTriggerExit()
    {
       // ui.SetActive(false);
    }

}
