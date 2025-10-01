using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGame : MonoBehaviour
{
    public void RestartGame()
    {
        SceneController.Instance.LoadScene("GameScene", false, false);
    }
}
