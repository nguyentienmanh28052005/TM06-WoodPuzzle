using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGame : MonoBehaviour
{
    public void RestartGame()
    {
        SceneController.Instance.LoadScene("Level" + GameManager.Instance.level, false, false);
    }

    public void OutLevel()
    {
        SceneController.Instance.LoadScene("GameMenu", false, false);

    }
}
