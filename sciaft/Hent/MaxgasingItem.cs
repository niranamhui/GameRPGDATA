using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxgasingItem : MonoBehaviour
{
    private Bullet Gum;
    //public GameObject healthEffect;
    private int MaxGum = 30;
    private void Start()
    {
        Gum = GameObject.FindGameObjectWithTag("BulletGum").GetComponent<Bullet>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Gum.bulletLife <= 29)
        {
            GumMax();
        }
    }
    public void GumMax()
    {
        Gum.bulletLife = MaxGum;
        Gum.textMax.text = Gum.bulletLife.ToString() + " /30";
        //Gum.TextGum();
        DesGum();
    }

    public void DesGum()
    {
        //this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
