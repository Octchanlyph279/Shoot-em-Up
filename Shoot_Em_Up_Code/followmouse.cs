using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour
{
    float yvalue;
    public float lolitspi;
    public float boundary2;
    // Start is called before the first frame update
    void Start()
    {
        yvalue = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        if (mousePosition.x > lolitspi)
        {
            transform.position = new Vector3(lolitspi, transform.position.y, 0);
        }
        else
        {
            if (mousePosition.x < -lolitspi)
            {
                transform.position = new Vector3(-lolitspi, transform.position.y, 0);
            }
        }
        if (mousePosition.y > boundary2)
        {
            transform.position = new Vector3(transform.position.x, boundary2, 0);
        }
        else
        {
            if (mousePosition.y < -boundary2)
            {
                transform.position = new Vector3(transform.position.x, -boundary2, 0);
            }
        }
        transform.rotation = Quaternion.identity;
    }
}
