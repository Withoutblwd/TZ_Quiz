using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DOTweenHandler : MonoBehaviour
{
    public void MoveTo(Vector3 pos,float duration)
    {
        transform.DOMove(pos,duration);
    }
    
    public void EaseInBounce()
    {
        transform.DORewind();    
        transform.DOShakePosition(2.0f, strength: new Vector3(0.2f, 0, 0), vibrato: 5,randomness:0,  snapping: false, fadeOut: true).SetEase(Ease.InBounce);
    }

    public void ScaleBounce()
    {
        transform.DORewind();
        transform.DOPunchScale((transform.localScale-new Vector3(0.3f,0.3f)), 0.3f,vibrato:0).SetEase(Ease.InOutQuad);
    }

    public void OutBounce()
    {
        Vector3 old = transform.localScale;
        transform.DOScale(Vector3.zero, 0f);
        transform.DOScale(old,1f);
    }
}
