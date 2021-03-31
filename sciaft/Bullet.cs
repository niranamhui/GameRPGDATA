using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int bulletLife;
    public bool allowButtonHold;
    bool shooting;

    public float fireRate; //ตัวรั้งเวลายิง
    private float nextFire; // เวลาที่จะยิงนัดต่อไป
    private bool canShoot = true;

    public float delayShoot;
    public float _currentLaunchForce;
    private bool _fired;
    public float minLaunchForce = 15f;
    Animator animetion;
    public TMPro.TMP_Text textMax;

    public GameObject healthEffect;
    private enamy enamyEff;

    private MaxgasingItem Guum;

   // public TMPro.TMP_Text textMax;
    public int magazineSize;

    // Start is called before the first frame update
    void Start()
    {
        enamyEff = GameObject.FindGameObjectWithTag("Enamy").GetComponent<enamy>();
        animetion = GetComponent<Animator>();

        bulletLife = magazineSize;


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            textMax.text = bulletLife.ToString() + " /30";
        }

        
        if (Input.GetButton("Fire1") && bulletLife >= 0)
        {
           
            if (Time.time > nextFire)
            {
                bulletLife--;
                TextGum();
                CmdFire();
            }
            //animetion.SetInteger("Animetion", 2);
        }

        if (Input.GetKey(KeyCode.G))
        {
            bulletLife = 0 ;
         }

        else if (Input.GetKeyDown(KeyCode.R) && bulletLife <= 29)
        {
            Guum.GumMax();
        }
    }
    void CmdFire()
    {
       
        nextFire = Time.time + fireRate;
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.transform.Rotate(180, 0, 0);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * -80.0f;

       
        Destroy(bullet, 2);
        canShoot = false;
    }

    public void TextGum()
    {
        textMax.text = bulletLife.ToString() + " /30";
        //bulletLife--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enamy"))
        {
            Instantiate(healthEffect, enamyEff.transform.position, Quaternion.identity);
            Destroy(bulletPrefab);
        }
    }
}
