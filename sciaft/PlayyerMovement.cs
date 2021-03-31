using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayyerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

   
    public float gravity ;
    public float jumpHeight ;
    Vector3 velocity;

    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask ;
    Animator animetion;

    public Transform tpLoc;
    public GameObject Player;
    private bool War;
    /*
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float fireRate; //ตัวรั้งเวลายิง
    private float nextFire; // เวลาที่จะยิงนัดต่อไป
    private bool canShoot = true;

    public float delayShoot;
    public float _currentLaunchForce;
    private bool _fired;
    public float minLaunchForce = 15f; */
    private void Start()
    {
        animetion = GetComponent<Animator>();

        War = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Teleport"))
        {
            War = true;
        }
        //ui.SetActive(true);
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (War)
        {
            if (Input.GetKey(KeyCode.P))
            {
                Player.gameObject.transform.position = tpLoc.transform.position;
                Debug.Log("OK");
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            animetion.SetInteger("Animetion", 1);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animetion.SetInteger("Animetion", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animetion.SetInteger("Animetion", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animetion.SetInteger("Animetion", 1);
        }
        else if (Input.GetButtonDown("Jump"))
        {
            animetion.SetInteger("Animetion", 3);
        }

        else
        {
            animetion.SetInteger("Animetion", 0);
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)//ถ้ากดกระโดนและตัวละครอยู่ที่Groundedจึงสามารถกระโดดได้
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animetion.SetInteger("Animetion", 3);
        }

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
