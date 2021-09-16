using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyHealth[] enemyList; //Stores the enemy health of all enemies
    public List<Chest> chests = new List<Chest>(); //List of chests
    List<int> groupsWithChests = new List<int>(); //List groups with a hidden chest
    public event Action<int> OnDmgTaken; //This is considered a different event then the one the Enemy Health Invoked

    // Start is called before the first frame update
    void Start()
    {
        foreach(EnemyHealth enemy in enemyList)
        {
            enemy.OnDmgTaken += Alert; //Add the function to the event else it won't be called
            enemy.OnDefeat += ChestSpawn;
        }
        foreach (Chest hiddenChest in chests)
        {
            groupsWithChests.Add(hiddenChest.group);
        }
    }

    void Alert(int group)
    {
        OnDmgTaken.Invoke(group); //An enemy has taken damage, so tell every other enemy to check if they are in the same group.
    }

    void ChestSpawn(int group)
    {
        if (groupsWithChests.Contains(group)) //Check to see if the group has a chest that can be spawned
        {
            int remaining = 0;
            foreach (EnemyHealth enemy in enemyList) 
            {
                if (enemy.group == group)
                {
                    print(remaining);
                    remaining++;
                }   
            }
            print(remaining);
            if(remaining == 0)
                chests[groupsWithChests.IndexOf(group)].gameObject.SetActive(true); //Activate chest
            return;
        }    
    }
}
