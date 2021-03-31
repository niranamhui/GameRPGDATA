using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelee : MonoBehaviour
{
    public GameObject Efface;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enamy"))
        {
            Instantiate(Efface,transform.position, Quaternion.identity);
            Destroy(gameObject,1);
        }
    }
}
