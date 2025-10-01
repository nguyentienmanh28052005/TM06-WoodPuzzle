using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool canMove = false;
    public bool busy = false;
    void Update()
    {
        // if (canMove && Vector2.Distance(GameManager.Instance.currentScrew.transform.position,
        //         GameManager.Instance.currentScrewNut.transform.position) < 0.001f)
        // {
        //     canMove = false;
        //     
        // }
        // if (canMove && GameManager.Instance.currentScrew != null)
        // {
        //         GameManager.Instance.currentScrew.MoveToScrewNut(GameManager.Instance.currentScrewNut.transform);
        // }    
    }
}
