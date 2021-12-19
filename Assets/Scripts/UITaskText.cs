using UnityEngine;
using UnityEngine.UI;

public class UITaskText : MonoBehaviour
{
    Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void UpdateTaskText(string currentObject)
    {
        _text.text = "Find " + currentObject;
    }
}
