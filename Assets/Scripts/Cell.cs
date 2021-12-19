using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    GameObject _cardSprite;
    [NonSerialized]
    public Vector3 CellSize;
    [NonSerialized]
    public Vector3 CardSpriteSize;

    string _identifier;
    float _rotationAngle;
    Sprite _cellSprite;

    void Awake()
    {
        CellSize = Vector3.Scale(gameObject.GetComponent<BoxCollider2D>().size, gameObject.GetComponent<Transform>().localScale);
        CardSpriteSize = Vector3.Scale(CellSize, _cardSprite.GetComponent<Transform>().localScale);
    }

    void OnMouseDown()
    {
        GameObject.Find("CardChecker").GetComponent<CardChecker>().CompareCardIdentifiers(_identifier, this);
    }

    public void SetCellParameters(string identifier, Sprite sprite, float rotationAngle)
    {
        _identifier = identifier;
        _cellSprite = sprite;
        _rotationAngle = rotationAngle;
        VisualizeSprite();
    }

    void VisualizeSprite()
    {
        _cardSprite.GetComponent<SpriteRenderer>().sprite = _cellSprite;
        _cardSprite.transform.rotation = Quaternion.identity;
        _cardSprite.transform.Rotate(new Vector3(0, 0, -_rotationAngle));
    }
}
