using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Shoot : MonoBehaviour
{
    public float rotationspeed;
    public float reload;
    public GameObject bullet;
    public float length;
    float timer = 0;
    public float x;
    public float y;
    public float speed;
    public float time;
    float timer2 = 0;
    float startx;
    float starty;
    public int HP;
    int health;
    bool stuck = false;
    public SCORE why;
    public GameObject tripleshotpowerup;
    public int probability;
    float random = 0;
    public int points;
    public GameObject soundeffect;
    float ypos;
    // Start is called before the first frame update
    void Start()
    {
        startx = transform.position.x;
        starty = transform.position.y;
        health = HP;
        why = GameObject.FindGameObjectWithTag("OKAY").GetComponent<SCORE>();
        ypos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startx, ypos, 0);
        transform.Rotate(0, 0, rotationspeed * Time.deltaTime);
        if (timer > reload)
        {
            shootbullets(transform.eulerAngles.z);
            shootbullets(transform.eulerAngles.z - 180);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
        timer2 += Time.deltaTime;
        if (timer2 > time)
        {
            stuck = false;
            ypos += speed * Time.deltaTime;
            if (ypos >= starty)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            ypos -= speed * Time.deltaTime;
            if (ypos <= y)
            {
                stuck = true;
            }
        }
        if (stuck == true)
        {
            transform.position = new Vector3(x, y, 0);
            ypos = y;
        }
        if (health <= 0)
        {
            random = Random.Range(0,(float)probability);
            if (random < 1)
            {
                Instantiate(tripleshotpowerup, transform.position, Quaternion.identity);
            }
            Instantiate(soundeffect, transform.position, Quaternion.identity);
            why.addscore(points);
            Destroy(gameObject);
        }
    }
    public void shootbullets(float angle)
    {
        Instantiate(bullet, new Vector3(transform.position.x + (length * Mathf.Cos(Mathf.Deg2Rad * angle)), ypos + (length * Mathf.Sin(Mathf.Deg2Rad * angle)), 0), Quaternion.Euler(0, 0, angle));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            health--;
        }
    }
}
