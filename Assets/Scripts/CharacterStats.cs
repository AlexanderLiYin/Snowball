using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    [Tooltip("The max Hp text.")]
    [SerializeField] protected TMP_Text m_MaxHpValueText;
    [Tooltip("The attack text.")]
    [SerializeField] protected TMP_Text m_AttackValueText;
    [Tooltip("The defense text.")]
    [SerializeField] protected TMP_Text m_DefenseValueText;

    SnowPrincess player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
        Draw();
    }

    public void Draw()
    {
        //if (m_CharacterStats == null) { Initialize(); }

        //m_MaxHpValueText.text = m_CharacterStats.MaxHp.ToString();
        m_MaxHpValueText.text = player.maxHealth.ToString();
        //m_AttackValueText.text = m_CharacterStats.Attack.ToString();
        //m_DefenseValueText.text = m_CharacterStats.Defense.ToString();
    }
}
