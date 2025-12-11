using UnityEngine;

public class SpikeMover : MonoBehaviour
{
    public float speed = 3f;      // 左に流れる速さ（地面と同じくらいに）
    public float destroyX = -15f; // 画面左のかなり外で消す位置

    void Update()
    {
        // 左に移動
        transform.position += Vector3.left * speed * Time.deltaTime;

        // 画面外まで行ったら削除
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
