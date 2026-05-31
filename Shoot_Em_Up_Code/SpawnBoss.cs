using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    float timer;
    public float spawntime;
    public GameObject Boss;
    public GameObject HPBar;
    public float HPy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > spawntime)
        {
            Instantiate(Boss, transform.position, Quaternion.identity);
            Instantiate(HPBar);
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
