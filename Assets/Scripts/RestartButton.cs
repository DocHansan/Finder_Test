using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    public GameStarter GameStarter;

    public void ShowRestartButton()
    {
        gameObject.SetActive(true);
    }

    public void HideRestartButton()
    {
        gameObject.SetActive(false);
    }
}