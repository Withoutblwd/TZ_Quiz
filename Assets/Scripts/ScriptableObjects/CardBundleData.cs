using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardBandleData", menuName = "Card Bundle Data", order = 10)]
public class CardBundleData : ScriptableObject
{ 
    [SerializeField]
    private CardData[] _cardData;

    public CardData[] CardData => _cardData;
}
