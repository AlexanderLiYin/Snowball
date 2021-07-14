using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyDisplay : MonoBehaviour
{
    public TMP_Text display;
    public int initEnergy = 50;
    public int maxEnergy = 120;
    public float energyPerSec = 1;
    float energy;

    // Start is called before the first frame update
    void Start()
    {
        energy = initEnergy;
        DisplayEnergy(energy);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (energy < maxEnergy)
        {
            energy += Time.deltaTime * energyPerSec;
        }
        else
        {
            energy = maxEnergy;
        }
        DisplayEnergy(energy);
    }

    void DisplayEnergy(float energy)
    {
        display.SetText(((int)energy).ToString());
    }
}
