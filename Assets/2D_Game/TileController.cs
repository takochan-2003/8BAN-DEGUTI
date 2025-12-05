using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject groundSprite;   // GroundSprite éq
    public GameObject holeSprite;     // HoleSprite éq

    public void SetGround()
    {
        groundSprite.SetActive(true);   // Å© Ç±ÇÍ
        holeSprite.SetActive(false);
    }

    public void SetHole()
    {
        groundSprite.SetActive(false);  // Å© Ç±ÇÍ
        holeSprite.SetActive(true);
    }
}
