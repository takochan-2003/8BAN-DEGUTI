using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab;
    public Camera miniGameCamera;

    public float spawnY = -1.97f;
    public float minInterval = 2f;
    public float maxInterval = 4f;

    float spawnX;
    float timer;

    void Start()
    {
        if (miniGameCamera == null)
            miniGameCamera = Camera.main;

        float halfH = miniGameCamera.orthographicSize;
        float halfW = halfH * miniGameCamera.aspect;

        spawnX = halfW + 1.5f; // 画面右の外で出す
        timer = Random.Range(minInterval, maxInterval);
    }

    void Update()
    {
        if (MiniGameManager.Instance != null)
        {
            if (MiniGameManager.Instance.IsGameOver || MiniGameManager.Instance.IsPaused)
                return;   // ★ ポーズ中は新しい針を出さない
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnSpike();
            timer = Random.Range(minInterval, maxInterval);
        }
    }

    void SpawnSpike()
    {
        Vector3 pos = new Vector3(spawnX, spawnY, 0f);
        Instantiate(spikePrefab, pos, Quaternion.identity, transform);
    }

    // ミニゲームだけリセット
    public void ResetSpikes()
    {
        // すでに出ている針を全削除
        for (int i = transform.childCount - 1; i >= 0; i--)
            Destroy(transform.GetChild(i).gameObject);

        // タイマーも初期化
        timer = Random.Range(minInterval, maxInterval);
    }
}
