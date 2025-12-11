using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (MiniGameManager.Instance != null &&
            MiniGameManager.Instance.IsGameOver)
            return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -15f)
            Destroy(gameObject);
    }
}
