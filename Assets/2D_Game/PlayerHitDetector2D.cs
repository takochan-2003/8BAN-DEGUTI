using UnityEngine;

public class PlayerHitDetector2D : MonoBehaviour
{
    public string spikeTag = "Spike";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(spikeTag))
        {
            if (MiniGameManager.Instance != null)
            {
                MiniGameManager.Instance.GameOver();
            }
        }
    }

    // ‚à‚µ Spike ‘¤‚Ì Collider ‚ª Trigger ‚¶‚á‚È‚­‚Äu‚Ó‚Â‚¤‚Ì“–‚½‚èv‚È‚ç‚±‚Á‚¿”Å‚ğg‚¤
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(spikeTag))
        {
            if (MiniGameManager.Instance != null)
            {
                MiniGameManager.Instance.GameOver();
            }
        }
    }
    */
}
