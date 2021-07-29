using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizData
{
    
    
    private CardData _answer;

    public CardData Answer
    {
        get { return _answer; }
    }
    

    private CardData[] _variants;
    
    public CardData[] Variants
    {
        get { return _variants; }
    }

    public QuizData(CardData answer, CardData[] variants)
    {
        _answer = answer;
        _variants = variants;
    }
        
}
