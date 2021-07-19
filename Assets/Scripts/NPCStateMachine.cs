using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateMachine : MonoBehaviour
{
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    public Rigidbody2D rb;
    public float fireRate = 1;

    enum State {idle, attack}
    State state;
    float shootTime = 0;
    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        state = State.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.idle:
                print("Idle state");
                break;

            case State.attack:
                print("Attack state");
                break;
        }
    }
}
