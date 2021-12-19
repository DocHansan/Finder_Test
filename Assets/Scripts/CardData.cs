using System;
using UnityEngine;

[Serializable]
public class CardData
{
    public string Identifier;

    public Sprite Sprite;

    [Range (-90f, 90f)]
    public float RotationAngle;
}
