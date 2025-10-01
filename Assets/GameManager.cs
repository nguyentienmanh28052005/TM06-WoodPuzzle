using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    public GameController controller;

    public ScrewNut previosScrewNut;
    public ScrewNut currentScrewNut;
    public Screw currentScrew;
}
