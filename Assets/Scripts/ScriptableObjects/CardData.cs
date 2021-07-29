using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CardData
{
    [SerializeField]
    private string _identifier;
    [SerializeField]
    private Sprite _sprite;
    [SerializeField] 
    private Vector3 _offsetRotation = Vector3.zero;

    public string Identifier => _identifier;

    public Sprite Sprite => _sprite;
    
    public Vector3 OffsetRotation => _offsetRotation;

}
