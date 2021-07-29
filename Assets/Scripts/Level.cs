using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Level
{
    [SerializeField] 
    private int _variants;

    public int Variants
    {
        get { return _variants; }
    }
}
