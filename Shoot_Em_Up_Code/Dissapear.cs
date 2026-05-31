using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    public float time;
    float timer;
    public GameObject Boss;
    public float lasery;
    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > time)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
        transform.position = new Vector3(Boss.transform.position.x, Boss.transform.position.y + lasery, 0);
    }
}
