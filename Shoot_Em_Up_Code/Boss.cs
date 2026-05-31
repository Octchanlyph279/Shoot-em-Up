using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Boss : MonoBehaviour
{
    public int HP;
    int startHP;
    public int stage = 1;
    public float shootpoint;
    public GameObject missle;
    public GameObject bullet;
    public GameObject laser;
    public GameObject bounceprojectile;
    public float anglemin;
    public float anglemax;
    public float posx;
    public float lasery;
    public GameObject warning;
    float random;
    public bool spread = false;
    public float spreadtime;
    float timer = 0;
    public float waittime;
    float timer2 = 0;
    float timer3 = 0;
    public float warningtime;
    public float warningy;
    bool lazer = false;
    public int points;
    public SCORE why;
    public HPBar health;
    public float distance;
    public float speed;
    float starty;
    float direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        posx = transform.position.x;
        startHP = HP;
        why = GameObject.FindGameObjectWithTag("OKAY").GetComponent<SCORE>();
        health = GameObject.FindGameObjectWithTag("HPBar").GetComponent<HPBar>();
        health.maxhealth(HP);
        starty = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(posx, starty + distance * Mathf.Sin(direction * Mathf.Deg2Rad), 0);
        transform.rotation = Quaternion.identity;
        if (HP < startHP / 2)
        {
            stage = 2;
        }
        if (HP <= 0)
        {
            why.addscore(points);
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName: "YouWin");
        }
        if (stage == 1)
        {
            if (timer2 > waittime)
            {
                random = Random.Range((float)-1.5, (float)1);
                if (random < 0)
                {
                    spread = true;
                    spreadshot(Random.Range(10, 20));
                    timer2 = 0;
                }
                else
                {
                    spread = false;
                    shootmissle();
                    timer2 = -1;
                }
            }
            else
            {
                timer2 += Time.deltaTime;
                if (spread == true)
                {
                    if (timer > spreadtime)
                    {
                        spreadshot(Random.Range(10, 20));
                        spread = false;
                        timer = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
            }
        }
        else if (stage == 2)
        {
            if (timer3 > waittime)
            {
                random = Random.Range((float)0, (float)5);
                if (random < 2)
                {
                    spread = true;
                    lazer = false;
                    spreadshot(Random.Range(10, 20));
                    timer3 = 0;
                }
                if (random > 3)
                {
                    spread = false;
                    lazer = false;
                    bounceattack();
                    timer3 = -2;
                }
                if (random < 3 && random > 2)
                {
                    spread = false;
                    lazer = true;
                    Instantiate(warning, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                    timer3 = -warningtime;
                }
            }
            else
            {
                if (spread == true)
                {
                    if (timer > spreadtime)
                    {
                        spreadshot(Random.Range(10, 20));
                        spread = false;
                        timer = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                if (lazer == true)
                {
                    if (timer > warningtime)
                    {
                        shootlaser();
                        lazer = false;
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
        health.health(HP);
        direction += Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            HP--;
            Destroy(collision.gameObject);
        }
    }
    public void shootbullet(float angle)
    {
        Instantiate(bullet, new Vector3(transform.position.x + (shootpoint * Mathf.Cos(Mathf.Deg2Rad * angle)), transform.position.y - shootpoint, 0), Quaternion.Euler(0, 0, angle));
    }
    [ContextMenu("spreadshot")]
    public void spreadshot(float angle)
    {
        float chance = 0;
        chance = Random.Range(0, 3);
        if (chance > 1.5)
        {
            shootbullet(270 - 3 * angle);
            shootbullet(270 - 2 * angle);
            shootbullet(270 - 1 * angle);
            shootbullet(270);
            shootbullet(270 + 1 * angle);
            shootbullet(270 + 2 * angle);
            shootbullet(270 + 3 * angle);
        }
        else
        {
            shootbullet(270 - 5 * angle / 2);
            shootbullet(270 - 3 * angle / 2);
            shootbullet(270 - 1 * angle / 2);
            shootbullet(270 + 1 * angle / 2);
            shootbullet(270 + 3 * angle / 2);
            shootbullet(270 + 5 * angle / 2);
        }
    }
    [ContextMenu("missle")]
    public void shootmissle()
    {
        Instantiate(missle, new Vector3(transform.position.x, transform.position.y - shootpoint, 0), Quaternion.identity);
    }
    [ContextMenu("laser")]
    public void shootlaser()
    {
        Instantiate(laser, new Vector3(transform.position.x, transform.position.y + lasery, 0), Quaternion.identity);
    }

    public void shootbounce(float angle, Vector3 spawnpos)
    {
        Instantiate(bounceprojectile, spawnpos, Quaternion.Euler(0, 0, angle));
    }
    [ContextMenu("bounceshot")]
    public void bounceattack()
    {
        shootbounce(340, new Vector3(transform.position.x + shootpoint, transform.position.y - (shootpoint/2), 0));
        shootbounce(200, new Vector3(transform.position.x - shootpoint, transform.position.y - (shootpoint / 2), 0));
        shootbounce(225, new Vector3(transform.position.x - shootpoint, transform.position.y - shootpoint, 0));
        shootbounce(270, new Vector3(transform.position.x, transform.position.y - shootpoint, 0));
        shootbounce(315, new Vector3(transform.position.x + shootpoint, transform.position.y - shootpoint, 0));
    }
}
