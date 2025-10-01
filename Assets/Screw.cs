using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Screw : MonoBehaviour, IPointerDownHandler
{
    public CircleCollider2D collier;
    public bool screwed = true;

    public void Start()
    {
        collier = GetComponent<CircleCollider2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GameManager.Instance.controller.busy)
        {
            Debug.Log("OnPointerDown: " + gameObject.name);
            ScrewNut currentNut = GetComponentInParent<ScrewNut>();
            GameManager.Instance.currentScrewNut = currentNut;

            // Nếu có Screw đang được chọn và không phải Screw này
            if (GameManager.Instance.currentScrew != null && GameManager.Instance.currentScrew != this)
            {
                GameManager.Instance.currentScrew.SetStatusScrew(true, 0.2f); // Đặt lại Screw trước đó
            }

            // Cập nhật trạng thái cho Screw hiện tại
            if (GameManager.Instance.currentScrew == this && !screwed)
            {
                SetStatusScrew(true, 0.2f); // Nếu đã chọn, đặt lại trạng thái
            }
            else
            {
                SetStatusScrew(false, 0.2f); // Chọn Screw mới
            }
        }
        
    }

    public void SetStatusScrew(bool status, float time)
    {
        // Hủy các tween hiện tại trên transform
        transform.DOKill();

        if (status)
        {
            // Trạng thái screwed = true
            screwed = true;
            transform.DOScale(1f, time);
            transform.DORotate(new Vector3(0f, 0f, 0f), time).OnComplete(() =>
            {
                if (GameManager.Instance.currentScrew == this)
                {
                    GameManager.Instance.currentScrewNut.empty = false;
                    GameManager.Instance.currentScrewNut.collier.isTrigger = true;
                    collier.isTrigger = false;
                    GameManager.Instance.currentScrew = null; // Chỉ đặt lại nếu vẫn là Screw hiện tại
                }
            });
        }
        else
        {
            // Trạng thái screwed = false
            GameManager.Instance.currentScrew = this;
            // GameManager.Instance.currentScrewNut.empty = true;
            GameManager.Instance.currentScrewNut.collier.isTrigger = false;
            collier.isTrigger = true;
            transform.DOScale(1.3f, time);
            transform.DORotate(new Vector3(0f, 0f, 180f), time).OnComplete(() =>
            {
                screwed = false;
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