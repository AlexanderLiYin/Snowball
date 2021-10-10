using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    // Ability cooldown
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;

    public GameObject targetCircle;
    public GameObject rangeCircle;
    public Transform player;
    public float maxDistance = 5;
    public SnowPrincess princess;

    Vector2 position;
    Vector2 posUp;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();   
        //Disable/enable ability indicators
        if (!active && Input.GetKeyDown(KeyCode.Alpha1) && isCooldown == false)
        {
            Enable();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = (mousePos - (Vector2)player.position).normalized;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject != this.gameObject)
                {
                    posUp = new Vector2(hit.point.x, 10f);
                    position = hit.point;
                }
            }

            var hitPosDir = (hit.point - transform.position).normalized;
            float distance = Vector2.Distance(hit.point, transform.position);
            distance = Mathf.Min(distance, maxDistance);

            var newHitPos = (Vector2)transform.position + (lookDir * distance);
            targetCircle.transform.position = (newHitPos);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Disable();
        }
    }

    public void Enable()
    {
        targetCircle.SetActive(true);
        rangeCircle.SetActive(true);
        active = true;
        princess.canAttack = false;
    }

    public void Disable()
    {
        targetCircle.SetActive(false);
        rangeCircle.SetActive(false);
        active = false;
        princess.canAttack = true;
    }

    void Ability1()
    {
        if(Input.GetButtonDown("Fire1") && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 0;
            //Disable();
        }

        if(isCooldown)
        {
            abilityImage1.fillAmount += 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount >= 1)
            {
                abilityImage1.fillAmount = 1;
                isCooldown = false;
            }
        }
    }
}