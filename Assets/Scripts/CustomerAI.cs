using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAI : MonoBehaviour
{
    private Transform point1;
    private Transform point2;
    public bool hasBeenServed;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        point1 = GameObject.Find("Customer Point 1").GetComponent<Transform>();
        point2 = GameObject.Find("Customer Point 2").GetComponent<Transform>();

        transform.position = point2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenServed == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, point2.position, speed * Time.deltaTime);
        }
    }
}
