using UnityEngine;

public class RestartButton : MonoBehaviour
{
    bool _isButtonShowing = false;

    public void ShowRestartButton()
    {
        Invoke(nameof(SetButtonActive), 0.1f);
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