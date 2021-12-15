using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cell : MonoBehaviour
{
    public GameObject SpriteRenderer;

    int _identifier;
    float _rotationAngle;
    Sprite _cellSprite;

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Debug.Log("Sprite Clicked");
        Debug.Log(_identifier);
    }

    public void SetCellParameters(int identifier, Sprite sprite, float rotationAngle)
    {
        _identifier = identifier;
        _cellSprite = sprite;
        _rotationAngle = rotationAngle;
        VisualizeSprite();
    }

    void VisualizeSprite()
    {
        SpriteRenderer.GetComponent<SpriteRenderer>().sprite = _cellSprite;
        SpriteRenderer.transform.Rotate(new Vector3(0, 0, -_rotationAngle));
    }
}
