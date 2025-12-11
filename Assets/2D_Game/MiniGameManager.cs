using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    [Header("UI")]
    public GameObject gameOverUI;     // GameOver 表示パネル

    [Header("Player")]
    public Transform player;
    private Vector3 playerStartPos;
    private Rigidbody2D playerRb;
    private PlayerJump2D playerJump;

    [Header("Spike")]
    public SpikeSpawner spikeSpawner;

    public bool IsGameOver { get; private set; } = false;

    void Awake()
    {
        Instance = this;

        if (player != null)
        {
            playerStartPos = player.position;
            playerRb = player.GetComponent<Rigidbody2D>();
            playerJump = player.GetComponent<PlayerJump2D>();
        }

        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    void Update()
    {
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
            gameOverUI.SetActive(true);

        if (playerRb != null)
            playerRb.velocity = Vector2.zero;

        if (playerJump != null)
            playerJump.enabled = false;
    }

    public void RestartMiniGame()
    {
        IsGameOver = false;

        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        // プレイヤー再配置＆動きリセット
        player.position = playerStartPos;
        if (playerRb != null)
            playerRb.velocity = Vector2.zero;
        if (playerJump != null)
            playerJump.enabled = true;

        // 出てる針を全部消す
        if (spikeSpawner != null)
            spikeSpawner.ResetSpikes();
    }
}
