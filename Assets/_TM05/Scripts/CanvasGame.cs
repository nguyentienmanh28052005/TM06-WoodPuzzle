using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;


public class CanvasGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseImage;
    [SerializeField] private GameObject pausePanel;
    
    public void RestartGame()
    {
        SceneController.Instance.LoadScene("Level" + GameManager.Instance.level, false, false);
    }

    public void OutLevel()
    {
        SceneController.Instance.LoadScene("GameMenu", false, false);
    }

    // public void OnEnable()
    // {
    //     pausePanel.transform.DOScale(1, 1f).OnComplete(() => 
    //     {
    //         
    //     });
    // }
    //
    // public void OnDisable()
    // {
    //     pausePanel.transform.DOScale(0.1f, 1f);
    // }

    public void Pause()
    {
        pausePanel.SetActive(true);
        pauseImage.transform.DOScale(1.1f, 0.2f).OnComplete(() =>
        {
            pauseImage.transform.DOScale(1, 0.1f);
        });
    }

    public void ClosePause()
    {
        //pausePanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        pauseImage.transform.DOScale(1.1f, 0.15f).OnComplete(() =>
        {
            pauseImage.transform.DOScale(0.1f, 0.2f).OnComplete(() =>
            {
                pausePanel.SetActive(false);
            });
        });
    }
}
