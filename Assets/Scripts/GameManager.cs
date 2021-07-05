using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUDScript HUD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Win()
    {
        print("You Win");
        HUD.Win();
    }

    public void Lose()
    {
        print("You Lost");
        HUD.Lose();
    }
}
