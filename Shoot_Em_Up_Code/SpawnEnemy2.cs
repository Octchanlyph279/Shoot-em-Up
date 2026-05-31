using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy2 : MonoBehaviour
{
    public GameObject Enemy2;
    public float xpos;
    public float ymin;
    public float ymax;
    public float spawnrate;
    public float startspawn;
    float timer;
    float timer2 = 0;
    float cool;
    float realxpos;
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
        if (timer3 < bossspawn)
        {
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
            else
            {
                timer2 += Time.deltaTime;
            }
            timer3 += Time.deltaTime;
        }
    }
    public void spawnenemy()
    {
        cool = Random.Range(-xpos, xpos);
        if (cool > 0)
        {
            realxpos = xpos;
        }
        else
        {
            realxpos = -xpos;
        }
        Instantiate(Enemy2, new Vector3(realxpos, Random.Range(ymin, ymax), 0), Quaternion.identity);
    }
}
