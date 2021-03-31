using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(dir*Time.deltaTime * 5,Space.World);


        Vector3 rot = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        //if (Input.GetKey("up"))
        {
            transform.Rotate(rot*250*Time.deltaTime,Space.World);
        }

        //if (Input.GetKey("right"))
        {
        //    transform.Rotate(0, 0, 1);
        }


	}
}
