using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject snowballPrefab;
    public float bulletForce = 20f;
    float attackTime = 0;
    public float attackRate = 2; // attacks per a second

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= attackTime)
        {
            if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
            {
                Attack();
                attackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        GameObject snowball = Instantiate(snowballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
