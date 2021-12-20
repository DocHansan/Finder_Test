using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    GameObject _cardSprite;

    [NonSerialized]
    Vector3 _cellSize;
    [NonSerialized]
    Vector3 _cardSpriteSize;

    public Vector3 CellSize => _cellSize;
    public Vector3 CardSpriteSize => _cardSpriteSize;

    SpriteRenderer _cardSpriteRenderer;
    Transform _cardSpriteTransform;
    CardChecker _cardChecker;
    string _identifier;
    CellAnimator _cellAnimator;

    void Awake()
    {
        _cardSpriteRenderer = _cardSprite.GetComponent<SpriteRenderer>();
        _cardSpriteTransform = _cardSprite.GetComponent<Transform>();
        _cellSize = Vector3.Scale(gameObject.GetComponent<BoxCollider2D>().size, gameObject.GetComponent<Transform>().localScale);
        _cardSpriteSize = Vector3.Scale(CellSize, _cardSpriteTransform.localScale);
        _cellAnimator = GetComponent<CellAnimator>();
        _cardChecker = GameObject.Find("CardChecker").GetComponent<CardChecker>();
    }

    void OnMouseDown()
    {
        _cardChecker.CompareCardIdentifiers(_identifier, _cellAnimator);
    }

    public void SetCellParameters(string identifier, Sprite sprite, float rotationAngle)
    {
        _identifier = identifier;
        _cardSpriteRenderer.sprite = sprite;
        _cardSpriteTransform.rotation = Quaternion.identity;
        _cardSpriteTransform.Rotate(new Vector3(0, 0, rotationAngle));
    }
}
