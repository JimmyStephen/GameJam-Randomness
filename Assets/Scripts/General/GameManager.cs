using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int Score { get; private set; }
    [HideInInspector] public KinematicCharacterController.Walkthrough.LandingLeavingGround.MyCharacterController Player;

    public int TotalZombies { get; private set; }
    [SerializeField] int MaxZombies = 100;
    public bool SpawnZombies { get { return MaxZombies > TotalZombies; } }

    public void StartGame()
    {
        //Debug.Log("Start Game Called | Not Implemented");
        Pause.Instance.paused = false;
        Score= 0;
    }
    public void GameOver()
    {
        //Debug.Log("Game Over Called | Not Implemented");
    }

    public void UpdateScore(int Update)
    {
        Score += Update;
        //Debug.Log($"Score: {Score}");
    }
    public void UpdateTotalZombies(int Update)
    {
        TotalZombies += Update;
        //Debug.Log($"Total Zombies: {TotalZombies}/{MaxZombies}");
    }
}
