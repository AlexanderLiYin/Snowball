using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Slider slider;

    public void HP(int health)
    {
        slider.value = health;
    }
}
