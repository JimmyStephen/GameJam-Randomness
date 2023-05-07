using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int Score { get; private set; }
    public float PlayerHealth { get; private set; }
    public float PlayerMana { get; private set; }

    public int TotalZombies { get; private set; }
    [SerializeField] int MaxZombies = 100;
    public bool SpawnZombies { get { return MaxZombies > TotalZombies; } }

    public void StartGame()
    {
        Debug.Log("Start Game Called | Not Implemented");
    }
    public void GameOver()
    {
        Debug.Log("Game Over Called | Not Implemented");
    }

    public void UpdatePlayerData(float Health, float Mana)
    {
        PlayerHealth = Health;
        PlayerMana = Mana;
    }
    public void UpdateScore(int Update)
    {
        Score += Update;
        //Debug.Log($"Score: {Score}");
    }
    public void UpdateTotalZombies(int Update)
    {
        TotalZombies += Update;
        Debug.Log($"Total Zombies: {TotalZombies}");
    }
}
