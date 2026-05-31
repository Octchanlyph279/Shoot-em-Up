using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy3 : MonoBehaviour
{
    float timer;
    float timer2 = 0;
    public float spawnrate;
    public float startspawn;
    public GameObject enemy;
    float timer3 = 0;
    public float bossspawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnrate;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer3 < bossspawn + 1)
        {
            timer2 += Time.deltaTime;
            if (timer2 > startspawn)
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
            }
            timer3 += Time.deltaTime;
        }
    }
    public void spawnenemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
