using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardData
{
    [SerializeField]
    public string Identifier;

    [SerializeField]
    public Sprite Sprite;

    [SerializeField][Range (-90f, 90f)]
    public float RotationAngle;
}
