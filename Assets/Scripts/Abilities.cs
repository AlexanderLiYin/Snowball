using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
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

    }

    // Update is called once per frame
    void Update()
    {
        //Disable/enable ability indicators
        if (!active && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enable();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Disable();
        }

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
}