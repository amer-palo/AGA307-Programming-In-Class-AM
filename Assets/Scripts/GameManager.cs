using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Title, Playing, Paused, GameOver};
public enum Difficulty { Easy, Medium, Hard};
public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public Difficulty difficulty;
    public int score;
    int scoreMultiplier = 1;
    void Start()
    {
        gameState = GameState.Title;
        
        switch(difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;

            case Difficulty.Medium:
                scoreMultiplier = 3;
                break;

            case Difficulty.Hard:
                scoreMultiplier = 5;
                break;

            default:
                scoreMultiplier = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
