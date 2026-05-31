using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    public GameObject bullet;
    public SCORE why;
    public enemymove move;
    public int location;
    public int HP;
    int health;
    public float shootpoint;
    public float reload;
    public int max;
    public int boundary;
    float timer;
    float timer2;
    public float range;
    public float basic;
    public GameObject soundeffect;
    // Start is called before the first frame update
    void Start()
    {
        timer = reload;
        health = HP;
        why = GameObject.FindGameObjectWithTag("OKAY").GetComponent<SCORE>();
    }

    // Update is called once per frame
    void Update()
    {
        timer2 += Time.deltaTime;
        if (timer < reload)
        {
            timer += Time.deltaTime;
        }
        else
        {
            shootbullet(basic + range);
            shootbullet(basic - range);
            timer = 0;
        }
        if (health <= 0)
        {
            if (timer2 < ((location - boundary) / move.speed))
            {
                why.addscore(100);
            }
            else
            {
                why.addscore(10 * Mathf.RoundToInt(((((boundary + move.boundary) - (timer2 - ((location - boundary)/move.speed)) * move.speed))/(boundary + move.boundary))*10));
            }
            Instantiate(soundeffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            health--;
        }
    }
    public void shootbullet(float angle)
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - shootpoint, 0), Quaternion.Euler(0,0,angle));
    }
}

