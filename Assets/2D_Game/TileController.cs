using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject groundSprite;   // 2D_GroundTile
    public GameObject holeSprite;     // 2D_HoleTile

    [Range(0f, 1f)]
    public float holeProbability = 0.3f;   // 穴の確率

    // allowHole = false → 必ず地面
    // allowHole = true  → ランダムで穴 or 地面
    public void SetRandom(bool allowHole)
    {
        if (!allowHole)
        {
            SetGround();
            return;
        }

        bool isHole = Random.value < holeProbability;

        if (isHole)
            SetHole();
        else
            SetGround();
    }

    public void SetGround()
    {
        if (groundSprite != null) groundSprite.SetActive(true);
        if (holeSprite != null) holeSprite.SetActive(false);
    }

    public void SetHole()
    {
        if (groundSprite != null) groundSprite.SetActive(false);
        if (holeSprite != null) holeSprite.SetActive(true);
    }
}
