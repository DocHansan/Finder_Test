using UnityEngine;
using UnityEngine.UI;

public class UITaskText : MonoBehaviour
{
    public void UpdateTaskText(string currentObject)
    {
        GetComponent<Text>().text = "Find " + currentObject;
    }
}
