using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootBullets : MonoBehaviour
{
    public GameObject bullet;
    public float shootpoint;
    public float reload;
    float timer;
    public static int HP;
    int health;
    public float angle;
    float timer2 = 0;
    public float dps;
    public bool tripleshot = false;
    public float spread;
    public float time;
    float timer3 = 0;
    public GameObject soundeffect;
    public int pointlifelost;
    // Start is called before the first frame update
    void Start()
    {
        timer = reload;
        health = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (timer < reload)
            {
                timer += Time.deltaTime;
            }
            else
            {
                if (tripleshot == true)
                {
                    shootbullet(angle);
                    shootbullet(angle - spread);
                    shootbullet(angle + spread);
                }
                else
                {
                    shootbullet(angle);
                }
                timer = 0;
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName: "GameOver");
        }
        if (tripleshot == true)
        {
            if (timer3 > time)
            {
                timer3 = 0;
                tripleshot = false;
            }
            else
            {
                timer3 += Time.deltaTime;
            }
        }
    }
    public void shootbullet(float angle)
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + shootpoint,0), Quaternion.Euler(0, 0, angle));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            SCORE.score -= pointlifelost;
            health--;
        }
        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            SCORE.score -= pointlifelost;
            health -= 2;
        }
        if (collision.gameObject.layer == 10)
        {
            health = 0;
            SCORE.score -= 5 * pointlifelost;
        }
        if (collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
            SCORE.score -= 3 * pointlifelost;
            health -= 3;
        }
        if (collision.gameObject.layer == 12)
        {
            Destroy(collision.gameObject);
            SCORE.score -= pointlifelost;
            health -= 2;
        }
        if (collision.gameObject.layer == 13)
        {
            Destroy(collision.gameObject);
            Instantiate(soundeffect, transform.position, Quaternion.identity);
            tripleshot = true;
            timer3 = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if (timer2 > (1 / dps))
            {
                health--;
                timer2 = 0;
            }
            else
            {
                timer2 += Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            timer2 = 0;
            timer2 += Time.deltaTime;
        }
    }
}
