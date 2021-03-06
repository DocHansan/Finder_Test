using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameField _gameField;
    [SerializeField]
    FadeAnimator _taskText;

    void Start()
    {
        _taskText.FadeIn();
        _gameField.ChangeLevelComplexity();
    }
}
