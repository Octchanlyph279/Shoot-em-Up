using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLives : MonoBehaviour
{
    public static bool livesset = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setlives(int lives)
    {
        ShootBullets.HP = lives;
        livesset = true;
    }
}
