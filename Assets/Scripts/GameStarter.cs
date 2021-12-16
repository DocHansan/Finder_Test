using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameField GameField;

    public void StartGame()
    {
        GameField.GetComponent<GameField>().RestartGame();
    }
}
