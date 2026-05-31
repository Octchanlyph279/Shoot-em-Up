using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCORE : MonoBehaviour
{
    public static int score;
    public int whyisntitvisible;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    void Update()
    {
        whyisntitvisible = score;
    }

    public void addscore(int points)
    {
        score += points;
    }
}
