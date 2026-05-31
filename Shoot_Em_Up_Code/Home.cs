using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public float hometime;
    public float time;
    public float speed;
    public float HP;
    float timer = 0;
    public GameObject Player;
    public float angle;
    float dify = 0;
    float difx = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
            if (timer > hometime)
            {
                transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Deg2Rad * angle) * speed * Time.deltaTime, transform.position.y + Mathf.Sin(Mathf.Deg2Rad * angle) * speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
                difx = Player.transform.position.x - transform.position.x;
                dify = Player.transform.position.y - transform.position.y;
                angle = Mathf.Atan2(dify, difx) * Mathf.Rad2Deg;
            }
            timer += Time.deltaTime;
        }
        transform.rotation = Quaternion.identity;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            HP--;
        }
    }
}
