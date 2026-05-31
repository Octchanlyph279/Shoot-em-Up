using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed;
    public float boundaryx;
    public float boundaryy;
    public float direction;
    public float time;
    float timer = 0;
    public float range;
    bool bounce = true;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > time)
        {
            bounce = false;
        }
        transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Deg2Rad * direction) * speed * Time.deltaTime, transform.position.y + Mathf.Sin(Mathf.Deg2Rad * direction) * speed * Time.deltaTime, 0);
        if (bounce == true)
        {
            if (transform.position.y > boundaryy)
            {
                direction = -direction;
                direction = Random.Range(direction - range, direction + range);
            }
            if (transform.position.y < -boundaryy)
            {
                direction = -direction;
                direction = Random.Range(direction - range, direction + range);
            }
            if (transform.position.x > boundaryx)
            {
                direction = direction + ((270 - direction) * 2);
                direction = Random.Range(direction - range, direction + range);
            }
            if (transform.position.x < -boundaryx)
            {
                direction = direction + ((270 - direction) * 2);
                direction = Random.Range(direction - range, direction + range);
            }
            direction = direction % 360;
        }
    }
}
