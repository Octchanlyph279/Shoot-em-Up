using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public float speed;
    public float boundary;
    float xpos;
    float prevy;
    // Start is called before the first frame update
    void Start()
    {
        xpos = transform.position.x;
        prevy = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(xpos, prevy, 0);
        transform.rotation = Quaternion.identity;
        prevy -= speed * Time.deltaTime;
        if (prevy < -boundary && transform.position.y < -boundary)
        {
            Destroy(gameObject);
        }
    }
}

