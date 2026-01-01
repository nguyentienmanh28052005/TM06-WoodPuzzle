using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Screw : MonoBehaviour, IPointerDownHandler
{
    public CircleCollider2D collier;
    public bool screwed = true;
    public ParticleSystem particalEffect;

    public void Awake()
    {
        transform.localScale = Vector3.zero;
        transform.DORotate(new Vector3(0f, 0f, 180f), 0);
    }

    public void OnEnable()
    {
        transform.DOScale(1.5f, 0.2f).OnComplete(() =>
        {
            transform.DOScale(1f, 0.2f);
            transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f).OnComplete(() =>
            {
            
            });
        });
    }

    public void Start()
    {
        collier = GetComponent<CircleCollider2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.Instance.busy)
        {
            Debug.Log("OnPointerDown: " + gameObject.name);
            ScrewNut currentNut = GetComponentInParent<ScrewNut>();
            GameManager.Instance.currentScrewNut = currentNut;

            if (GameManager.Instance.currentScrew != null && GameManager.Instance.currentScrew != this)
            {
                GameManager.Instance.currentScrew.SetStatusScrew(true, 0.2f); 
            }
            
            if (GameManager.Instance.currentScrew == this && !screwed)
            {
                SetStatusScrew(true, 0.2f); 
            }
            else
            {
                SetStatusScrew(false, 0.2f); 
            }
        }
        
    }

    public void SetStatusScrew(bool status, float time)
    {
        transform.DOKill();
        if (status)
        {
            screwed = true;
            transform.DOScale(1f, time);
            transform.DORotate(new Vector3(0f, 0f, 0f), time).OnComplete(() =>
            {
                if (GameManager.Instance.currentScrew == this)
                {
                    particalEffect.Clear();
                    particalEffect.Play();
                    GameManager.Instance.currentScrewNut.empty = false;
                    GameManager.Instance.currentScrewNut.collier.isTrigger = true;
                    collier.isTrigger = false;
                    GameManager.Instance.currentScrew = null;
                }
            });
        }
        else
        {
            screwed = false;
            GameManager.Instance.currentScrew = this;
            // GameManager.Instance.currentScrewNut.empty = true;
            GameManager.Instance.currentScrewNut.collier.isTrigger = false;
            collier.isTrigger = true;
            transform.DOScale(1.3f, time);
            transform.DORotate(new Vector3(0f, 0f, 180f), time).OnComplete(() =>
            {
                
            });
        }
    }

    public void MoveToScrewNut(Transform trans)
    {
        transform.DOMove(trans.position, 0.15f).OnComplete(() =>
        {
            GameManager.Instance.currentScrew.collier.isTrigger = false;
            GameManager.Instance.currentScrewNut.empty = false;
            GameManager.Instance.currentScrew.transform.SetParent(GameManager.Instance.currentScrewNut.transform);
            GameManager.Instance.currentScrew.SetStatusScrew(true, 0.2f);
        });
    }
}