using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0.05f, 0, 0);
        if(transform.position.x <= -40.0025f)
        {
            Instantiate(gameObject, new Vector3(120.01f, 0, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
