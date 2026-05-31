using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trackscore : MonoBehaviour
{
    public int score = 0;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("SCORE").GetComponent<Text>();
        score = SCORE.score;
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
