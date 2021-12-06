using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    //Energy
    HUDScript HUD;
    public int initEnergy = 50;
    public int maxEnergy = 120;
    public float energyPerSec = 1;
    float energy;

    // Start is called before the first frame update
    void Start()
    {
        try {HUD = GameObject.Find("HUD").GetComponent<HUDScript>(); }
        catch { print("Error, HUD not found"); }
        // Display Energy
        energy = initEnergy;
        HUD.DisplayEnergy(energy, maxEnergy);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Energy Generation
        if (energy < maxEnergy)
        {
            energy += Time.deltaTime * energyPerSec;
        }
        else
        {
            energy = maxEnergy;
        }
        HUD.DisplayEnergy(energy, maxEnergy);
    }

    public void incEnergy(int inc)
    {
        if ((inc + energy) > maxEnergy)
            energy = maxEnergy;
        else
        {
            energy = energy + inc;
        }
    }

    public bool decEnergy(int cost)
    {
        if (cost > energy)
            return false;
        else
        {
            energy = energy - cost;
            return true;
        }
    }

    public void incMaxEnergy(int energy)
    {
        maxEnergy += energy;
        HUD.DisplayEnergy(energy, maxEnergy);
    }

    public bool decMaxEnergy(int energy)
    {
        if ((maxEnergy - energy) > 0)
        {
            maxEnergy -= energy;
            return true;
        }
        else return false;
    }

    public void incEnergyRecharge(float rate)
    {
        energyPerSec += rate;
    }

    public bool decEnergyRecharge(float rate)
    {
        if ((energyPerSec - rate) > 0)
        {
            energyPerSec -= rate;
            return true;
        }
        else return false;
    }
}
