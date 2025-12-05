using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject tilePrefab;     // Tile（Ground + Hole切替可能）のPrefab
    public float tileWidth = 2f;      // タイル幅（Xスケール）
    public int tileCount = 16;        // タイル枚数
    public float speed = 3f;

    private List<GameObject> tiles = new List<GameObject>();

    // MiniGameCamera をインスペクタからドラッグ
    public Camera miniGameCamera;

    float resetX;

    void Start()
    {
        // ★ カメラから安全なリセット位置を自動計算
        if (miniGameCamera == null)
        {
            miniGameCamera = Camera.main;
        }

        float halfHeight = miniGameCamera.orthographicSize;              // = 5
        float halfWidth = halfHeight * miniGameCamera.aspect;            // ≒ 8.89

        // 画面左端よりさらにタイル 1.5 枚ぶん左でリセット
        resetX = -halfWidth - tileWidth * 1.5f;                          // ≒ -11.9

        // タイルの初期配置（0 から右方向へ）
        float startX = -halfWidth - tileWidth;                           // 左端の少し左から並べる

        for (int i = 0; i < tileCount; i++)
        {
            Vector3 pos = new Vector3(startX + tileWidth * i, 0f, 0f);
            GameObject t = Instantiate(tilePrefab, pos, Quaternion.identity, transform);

            // ★ 最初は必ず地面にしておく（穴からスタートしないように）
            var controller = t.GetComponent<TileController>();
            controller.SetRandom(false);

            tiles.Add(t);
        }
    }

    void Update()
    {
        foreach (var t in tiles)
        {
            t.transform.position += Vector3.left * speed * Time.deltaTime;

            // 完全に画面外（左）に出たらループ
            if (t.transform.position.x < resetX)
            {
                float maxX = GetMaxTileX();
                t.transform.position = new Vector3(
                    maxX + tileWidth,
                    t.transform.position.y,
                    t.transform.position.z
                );

                // ★ このタイミング「だけ」ランダム穴にする
                var controller = t.GetComponent<TileController>();
                controller.SetRandom(true);
            }
        }
    }

    float GetMaxTileX()
    {
        float max = float.NegativeInfinity;
        foreach (var t in tiles)
        {
            if (t.transform.position.x > max)
                max = t.transform.position.x;
        }
        return max;
    }
}
