using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataSetsHandler 
{
    private CardBundleData[] _cardSets = null;
    public CardBundleData[] CardSets
    {
        get { return _cardSets; }
    }

    private  List<CardData> _used = new List<CardData>();
    
    public void ClearUsed()
    {
        _used.Clear();
    }
    
    public void LoadCards()
    {
        Object[] objs = Resources.LoadAll("CardBundles", typeof(CardBundleData));
        _cardSets = new CardBundleData[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            _cardSets[i] = (CardBundleData)objs[i];
        }
    }

    public QuizData GetQuiz(int variants)
    {
        CardData answer = null;
        List<CardData> cards = new List<CardData>();
        CardBundleData cardSet = _cardSets[Random.Range(0, _cardSets.Length)];
        System.Random r = new System.Random();
        do
        {
            foreach (int i in Enumerable.Range(0, cardSet.CardData.Length).OrderBy(x => r.Next()))
            {
                if (answer is null)
                {
                    if (!_used.Contains(cardSet.CardData[i])) answer = cardSet.CardData[i];
                }
                if (cards.Count == variants) break;
                cards.Add(cardSet.CardData[i]);
                


            }
        } while (cards.Count<variants || answer is null);

        _used.Add(answer);
        return  new QuizData(answer,cards.ToArray());
    }

    
}
