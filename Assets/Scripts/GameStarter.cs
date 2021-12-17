using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    public GameField GameField;
    [SerializeField]
    public Button RestartButton;
    [SerializeField]
    public Text TaskText;
    [SerializeField]
    public FadeAnimator TestAnim;

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        RestartButton.GetComponent<RestartButton>().HideRestartButton();
        TestAnim.FadeIn(2f, TaskText);
        GameField.GetComponent<GameField>().ResetField();
    }
}
