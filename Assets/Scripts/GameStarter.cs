using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameField _gameField;
    [SerializeField]
    GameObject _taskText;

    FadeAnimator _fadeAnimator;

    void Awake()
    {
        _fadeAnimator = _taskText.GetComponent<FadeAnimator>();
    }

    void Start()
    {
        _fadeAnimator.Fade(true);
        _gameField.ResetField();
    }
}
