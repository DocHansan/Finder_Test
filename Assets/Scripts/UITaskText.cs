using UnityEngine;
using UnityEngine.UI;

public class UITaskText : MonoBehaviour
{
    Text _text;
    FadeAnimator _fadeAnimator;

    void Awake()
    {
        _text = GetComponent<Text>();
        _fadeAnimator = GetComponent<FadeAnimator>();
    }

    public void UpdateTaskText(string currentObject)
    {
        _text.text = "Find " + currentObject;
    }

    public void Fade()
    {
        _fadeAnimator.FadeIn();
    }
}
