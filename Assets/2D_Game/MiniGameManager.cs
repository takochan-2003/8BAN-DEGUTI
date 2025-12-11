using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    [Header("UI")]
    public GameObject gameOverUI;   // GameOver表示用のパネル（Canvasの子）

    public bool IsGameOver { get; private set; } = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // シーンをまたがないなら DontDestroyOnLoad は不要
        // DontDestroyOnLoad(gameObject);

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);  // 最初は非表示
        }
    }

    void Update()
    {
        // GameOver中に R キーでリトライ
        if (IsGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartMiniGame();
        }
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // 必要ならプレイヤーの動きを止めるなど
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }

            var jump = player.GetComponent<PlayerJump2D>();
            if (jump != null)
            {
                jump.enabled = false;
            }
        }
    }

    public void RestartMiniGame()
    {
        // 今のシーンをそのまま再読み込み
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}
