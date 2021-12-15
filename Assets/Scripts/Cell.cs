using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cell : MonoBehaviour
{
    [SerializeField]
    public GameObject SpriteRenderer;

    int _identifier;
    float _rotationAngle;
    Sprite _cellSprite;

    void OnMouseDown()
    {
        GameObject.Find("CardChecker").GetComponent<CardChecker>().CompareCardIdentifiers(_identifier);
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
        SpriteRenderer.transform.rotation = Quaternion.identity;
        SpriteRenderer.transform.Rotate(new Vector3(0, 0, -_rotationAngle));
    }
}
