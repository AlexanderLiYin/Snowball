using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopUp : MonoBehaviour
{
    TextMeshPro textMesh;
    public GameObject textPrefab;
    float moveYSpeed = 1f;
    float disTime;
    float disSpeed = 1f;
    Color textColor;

    public void Create(Vector3 position, int dmg, bool crit)
    {
        GameObject obj = Instantiate(textPrefab, position, Quaternion.identity);
        DmgPopUp damagePopUp = obj.GetComponent<DmgPopUp>();
        damagePopUp.Setup(dmg, crit);
    }

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }


    public void Setup(int damageAmount, bool crit)
    {
        textMesh.SetText(damageAmount.ToString());
        if(!crit)
        {
            textMesh.fontSize = 8;
        }
        else
        {
            textMesh.fontSize = 12;
        }
        textColor = textMesh.color;
        disTime = 1f;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disTime -= Time.deltaTime;
        if (disTime < 0)
        {
            textColor.a -= disSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
