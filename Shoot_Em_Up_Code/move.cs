using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    public float boundary;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Deg2Rad * direction) * speed * Time.deltaTime, transform.position.y + Mathf.Sin(Mathf.Deg2Rad * direction) * speed * Time.deltaTime, 0);
        if (transform.position.y > boundary || transform.position.y < -boundary)
        {
            Destroy(gameObject);
        }
    }
}
