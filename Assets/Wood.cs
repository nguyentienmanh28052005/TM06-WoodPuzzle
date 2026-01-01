using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public GameObject hit;
    
    public void Awake()
    {
        hit.SetActive(false);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        transform.DOScale(new Vector3(1.05f, 1.15f, 1.05f), 0.3f).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1, 1, 1), 0.05f).OnComplete(() =>
            {
                
            });
        });
    }

    public void AddCollider()
    {
        hit.SetActive(true);
        _rigidbody2D.gravityScale = 2;
    }
    
}

