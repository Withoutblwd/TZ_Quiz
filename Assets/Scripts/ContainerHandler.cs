using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ContainerHandler : MonoBehaviour,IPointerClickHandler
{
    
    [SerializeField] 
    private SpriteRenderer _variantSprite;

    [SerializeField]
    private UnityEvent _onWin;
    
    [SerializeField]
    private UnityEvent _onLose;
    
    private UnityEvent _onClick = new UnityEvent();
    
    [SerializeField]
    public UnityEvent OnStart;

    public void SetSprite(Sprite sprite)
    {
        _variantSprite.sprite = sprite;
    }

    
    
    

    public void MakeStandart()
    {
        _onClick.RemoveAllListeners();
        _onClick.AddListener(_onLose.Invoke);
    }
    
    public void MakeWinnable(UnityAction onWinAction)
    {
        _onWin.RemoveAllListeners();
        _onWin.AddListener(onWinAction);
        _onClick.RemoveAllListeners();
        _onClick.AddListener(_onWin.Invoke);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
            _onClick.Invoke();
    }


}
