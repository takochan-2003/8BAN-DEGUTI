using UnityEngine;

public class PlayerHitDetector2D : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            MiniGameManager.Instance.GameOver();
        }
    }
}
