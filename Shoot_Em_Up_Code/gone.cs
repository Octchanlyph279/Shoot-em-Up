using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gone : MonoBehaviour
{
    public float time;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
