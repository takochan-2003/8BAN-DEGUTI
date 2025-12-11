using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [Header("Spike Settings")]
    public GameObject spikePrefab;   // Spike プレハブ
    public float spawnY = -1.97f;    // 針の高さ（指定どおり固定）

    [Header("Spawn Interval")]
    public float minSpawnInterval = 1.0f; // 針が出る最短間隔（秒）
    public float maxSpawnInterval = 2.0f; // 針が出る最長間隔（秒）

    [Header("Camera")]
    public Camera miniGameCamera;    // MiniGame 用のカメラ（DebugMiniGameCamera）

    private float spawnX;            // 画面右の少し外側
    private float timer;             // 次のスポーンまでのタイマー

    void Start()
    {
        if (miniGameCamera == null)
        {
            miniGameCamera = Camera.main;
        }

        // カメラの横幅から「画面右端」を計算
        float halfH = miniGameCamera.orthographicSize;       // = 5
        float halfW = halfH * miniGameCamera.aspect;         // ≒ 8.9 (16:9)

        // 画面右端より少し外（+2）でスポーンする
        spawnX = halfW + 2f;

        // 最初のスポーンまでの時間をランダムに決める
        timer = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        // タイマーを減らす
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnSpike();

            // 次のスポーンまでの時間を再度ランダムに決める
            timer = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnSpike()
    {
        Vector3 pos = new Vector3(spawnX, spawnY, 0f);
        Instantiate(spikePrefab, pos, Quaternion.identity);
    }
}
