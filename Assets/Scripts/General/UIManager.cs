using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] TMP_Text HealthUI;
    [SerializeField] TMP_Text ManaUI;

    void Update()
    {
        ScoreUI.text    = "Score: "  + GameManager.Instance.Score.ToString();
        HealthUI.text   = "Health: " + GameManager.Instance.PlayerHealth.ToString("0.##");
        ManaUI.text     = "Mana: "   + GameManager.Instance.PlayerMana.ToString("0.##");
    }
}
