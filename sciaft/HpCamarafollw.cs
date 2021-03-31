using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCamarafollw : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
