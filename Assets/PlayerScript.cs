using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Transform target;
    public float t;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = target.position;


        //Vector3 a = transform.position;
        //Vector3 b = target.position;
        //transform.position = Vector3.Lerp(a, b, t);

        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, b, speed);
    }

}
