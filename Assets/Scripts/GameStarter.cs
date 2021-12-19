using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameField _gameField;
    [SerializeField]
    FadeAnimator _taskText;

    void Start()
    {
        _taskText.FadeIn();
        _gameField.CreateLevel();
    }
}
