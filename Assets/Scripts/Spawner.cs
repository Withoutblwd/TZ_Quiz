using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class Spawner : MonoBehaviour
{
    #region Variables

    [SerializeField] 
    private LevelManager _levelManager;
    public LevelManager LevelManager
    {
        get { return _levelManager; }
    }
    
    [SerializeField]
    private GameObject _container;
    
    [SerializeField]
    private float _minimalSqrt = 3;
    
    [SerializeField]
    private List<ContainerHandler> _pool = new List<ContainerHandler>();

    [SerializeField] 
    private Object _containerPrefab;

    private UnityEvent _collectionEvent = new UnityEvent();
    
    #endregion


    public void CallAllCards()
    {
        _collectionEvent.Invoke();
    }
    public void SpawnCards(QuizData dataSet)
    {
        PrepareCards(dataSet.Variants.Length);
        Place(dataSet.Variants.Length);
        SetCards(dataSet);
    }
    
    void PrepareCards(int variants)
    {
        //Instantiating new card prefabs if necessary
        for (int i = _pool.Count; i < variants; i++)
        { GameObject card  =(GameObject)Instantiate(_containerPrefab, gameObject.transform);
            
            _pool.Add(card.GetComponent<ContainerHandler>());
        }
        for(int i = 0; i < variants; i++)
        {
            _pool[i].gameObject.SetActive(true);
        }
        //Hiding overbounded cards
        for (int i = variants; i < _pool.Count; i++)
        {
            _pool[i].gameObject.SetActive(false);
        }
    }
    //Place cards in grid
    void Place(int variants)
    {
        //calculate maximum needed capacity of grid
        float maximumform = Mathf.Ceil(Mathf.Sqrt(variants)) > _minimalSqrt ? Mathf.Ceil(Mathf.Sqrt(variants)) : _minimalSqrt; 
        
        //calculate position and scale for cards
        for (int i = 0; i < variants; i++)
        {
            _pool[i].gameObject.transform.localScale = new Vector2(1 / maximumform,1 / maximumform);
            _pool[i].gameObject.transform.localPosition = new Vector2(
                Mathf.Floor(i % maximumform) / maximumform,
                -Mathf.Floor(i / maximumform) / maximumform )+new Vector2(-0.5f+_pool[i].transform.localScale.x/2f,0.5f-_pool[i].transform.localScale.y/2f);
            
        }
    }

    void SetCards(QuizData dataSet)
    {
        System.Random r = new System.Random();
        int k = 0;
        foreach (int i in Enumerable.Range(0, dataSet.Variants.Length).OrderBy(x => r.Next()))
        {
            _pool[k].SetSprite(dataSet.Variants[i].Sprite);
            _collectionEvent.AddListener(_pool[k].OnStart.Invoke);
            if (dataSet.Variants[i] == dataSet.Answer) _pool[k].MakeWinnable(_levelManager.NextQuiz);
            else _pool[k].MakeStandart();
            _pool[k].gameObject.transform.rotation = Quaternion.Euler(dataSet.Variants[i].OffsetRotation);
            k++;
                
        }
    }
}
