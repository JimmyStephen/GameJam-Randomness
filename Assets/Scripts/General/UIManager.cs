using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreUI;
    [SerializeField] Slider HealthSlider;
    [SerializeField] Slider ManaSlider;

    [SerializeField] Image MoonblastCD;
    [SerializeField] Image StarfallCD;
    [SerializeField] Image BlackholeCD;

    void Update()
    {
        ScoreUI.text    = "Score: "  + GameManager.Instance.Score.ToString();
        HealthSlider.value = GameManager.Instance.Player.Health.GetCurrent() / GameManager.Instance.Player.Health.GetMax() * 100;
        ManaSlider.value = GameManager.Instance.Player.Mana.GetCurrent() / GameManager.Instance.Player.Mana.GetMax() * 100;

        var newColor = MoonblastCD.color;
        newColor.a = 255 - GameManager.Instance.Player.GetCooldownPercent("Moonblast") * 255;
        MoonblastCD.color = newColor;

        newColor = StarfallCD.color;
        newColor.a = 255 - GameManager.Instance.Player.GetCooldownPercent("Starfall") * 255;
        StarfallCD.color = newColor;

        newColor = BlackholeCD.color;
        newColor.a = 255 - GameManager.Instance.Player.GetCooldownPercent("Blackhole") * 255;
        BlackholeCD.color = newColor;
    }
}
