using System;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField]
    string _identifier;
    [SerializeField]
    Sprite _sprite;
    [SerializeField][Range (-90f, 90f)]
    float _rotationAngle;

    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;
    public float RotationAngle => _rotationAngle;
}
