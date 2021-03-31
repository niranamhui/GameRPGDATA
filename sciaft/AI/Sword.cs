using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject swordeff;
    public GameObject posTra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guront"))
        {
            Instantiate(swordeff, posTra.transform.position, Quaternion.identity);
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Guront"))
        {
            Instantiate(swordeff, posTra.transform.position, Quaternion.identity);
        }
    }
}
