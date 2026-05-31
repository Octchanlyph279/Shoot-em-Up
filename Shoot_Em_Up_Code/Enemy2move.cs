using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2move : MonoBehaviour
{
    public float boundary;
    public float speed;
    public GameObject bullet;
    float ypos;
    float timer;
    public float reload;
    float timer2;
    public float shootpoint;
    int stage = 1;
    float xmove;
    public float end;
    float realend;
    public float wait;
    public int HP;
    int health;
    public int bullets;
    public SCORE why;
    public int points;
    public float angle;
    public GameObject tripleshotpowerup;
    public int probability;
    float random = 0;
    public GameObject soundeffect;
    int thing = 1;
    float xpos;
    // Start is called before the first frame update
    void Start()
    {
        timer = reload - wait;
        timer2 = 0;
        ypos = transform.position.y;
        xmove = Random.Range(-boundary, boundary);
        health = HP;
        xpos = transform.position.x;
        if (transform.position.x > 0)
        {
            realend = -end;
            thing = -1;
        }
        else
        {
            realend = end;
            thing = 1;
        }
        why = GameObject.FindGameObjectWithTag("OKAY").GetComponent<SCORE>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, ypos, 0);
        if (stage == 1)
        {
            if (thing * transform.position.x > thing * xmove)
            {
                stage++;
            }
            else
            {
                transform.position = new Vector3(xpos, ypos, 0);
                xpos += thing * speed * Time.deltaTime;
            }
        }
        if (stage == 2)
        {
            if (timer2 > bullets * reload + wait)
            {
                stage++;
            }
            else
            {
                if (timer > reload)
                {
                    shootbullet();
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
                timer2 += Time.deltaTime;
            }
        }
        if (stage == 3)
        {
            if (thing * transform.position.x > thing * realend)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector3(xpos, ypos, 0);
                xpos += thing * speed * Time.deltaTime;
            }
        }
        if (health <= 0)
        {
            random = Random.Range(0, (float)probability);
            if (random < 1)
            {
                Instantiate(tripleshotpowerup, transform.position, Quaternion.identity);
            }
            Instantiate(soundeffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            why.addscore(points);
        }
        transform.rotation = Quaternion.identity;
    }
    public void shootbullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - shootpoint, 0), Quaternion.Euler(0, 0, angle));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            health--;
            Destroy(collision.gameObject);
        }
    }
}
