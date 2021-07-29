using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDebugDraw : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR
        Gizmos.DrawWireCube(transform.position,transform.localScale);
        #endif
    }
}
