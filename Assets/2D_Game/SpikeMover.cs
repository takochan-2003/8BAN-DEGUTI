using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (MiniGameManager.Instance != null)
        {
            if (MiniGameManager.Instance.IsGameOver || MiniGameManager.Instance.IsPaused)
                return;   // ★ ゲームオーバー中 / 一時停止中は動かさない
        }

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
