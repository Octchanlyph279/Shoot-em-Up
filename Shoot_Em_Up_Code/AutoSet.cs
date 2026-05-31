using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSet : MonoBehaviour
{
    public int defaultvalue;
    // Start is called before the first frame update
    void Start()
    {
        if (SetLives.livesset == false)
        {
            ShootBullets.HP = defaultvalue;
            SetLives.livesset = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
