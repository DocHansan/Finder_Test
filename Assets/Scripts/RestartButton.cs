using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameStarter GameStarter;

    void OnMouseDown()
    {
        GameStarter.StartGame();
    }
}