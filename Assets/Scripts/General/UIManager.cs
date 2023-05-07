using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text ScoreUI;
    [SerializeField] TMPro.TMP_Text HealthUI;
    [SerializeField] TMPro.TMP_Text ManaUI;

    void Update()
    {
        ScoreUI.text    = "Score: "  + GameManager.Instance.Score.ToString();
        HealthUI.text   = "Health: " + GameManager.Instance.PlayerHealth.ToString();
        ManaUI.text     = "Mana: "   + GameManager.Instance.PlayerMana.ToString();
    }
}
