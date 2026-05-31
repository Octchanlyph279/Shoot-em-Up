using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void health(int health)
    {
        slider.value = health;
    }
    public void maxhealth(int max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
}
