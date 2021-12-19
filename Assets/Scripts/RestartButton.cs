using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void SetButtonActivity(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}