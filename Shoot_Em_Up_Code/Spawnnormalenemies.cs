using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnnormalenemies : MonoBehaviour
{
    public GameObject enemy;
    public float spawnrate;
    public float spawnrange;
    float timer;
    float range;
    float timer2 = 0;
    public float bossspawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnrate;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer2 < bossspawn)
        {
            if (timer > spawnrate)
            {
                spawnenemy();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
            timer2 += Time.deltaTime;
        }
    }
    public void spawnenemy()
    {
        range = Random.Range(-spawnrange, spawnrange);
        Instantiate(enemy, new Vector3(transform.position.x + range, transform.position.y, 0), Quaternion.identity);
    }
}
