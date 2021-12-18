using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    public GameStarter GameStarter;

    bool _isButtonShowing = false;

    public void ShowRestartButton()
    {
        Invoke("SetButtonActive", 0.1f);
    }

    void SetButtonActive()
    {
        if (!_isButtonShowing)
        {
            gameObject.SetActive(true);
            _isButtonShowing = true;
        }
    }

    public void HideRestartButton()
    {
        gameObject.SetActive(false);
        _isButtonShowing = false;
    }
}