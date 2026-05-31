using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float distance;
    public float speed;
    float starty;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        starty = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, starty + distance * (Mathf.Sin(angle * Mathf.Deg2Rad)), 0);
        angle += speed * Time.deltaTime;
    }
}
