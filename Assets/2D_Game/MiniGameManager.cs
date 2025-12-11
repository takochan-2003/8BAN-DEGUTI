using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    // シングルトン（どこからでも MiniGameManager.Instance でアクセス）
    public static MiniGameManager Instance { get; private set; }

    [Header("UI")]
    [Tooltip("ミニゲーム画面内に表示する GAME OVER パネル")]
    public GameObject gameOverUI;

    [Header("Player")]
    [Tooltip("ミニゲーム用プレイヤーの Transform")]
    public Transform player;

    [Header("Spike / Enemy")]
    [Tooltip("針をスポーンさせている SpikeSpawner")]
    public SpikeSpawner spikeSpawner;

    // 状態フラグ
    public bool IsGameOver { get; private set; } = false;
    public bool IsPaused { get; private set; } = false;   // ← フェード中一時停止

    // 内部用
    private Vector3 playerStartPos;
    private Rigidbody2D playerRb;
    private PlayerJump2D playerJump;

    void Awake()
    {
        // シングルトン初期化
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // プレイヤー情報をキャッシュ
        if (player != null)
        {
            playerStartPos = player.position;
            playerRb = player.GetComponent<Rigidbody2D>();
            playerJump = player.GetComponent<PlayerJump2D>();
        }

        // GAME OVER UI は最初は非表示
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    /// <summary>
    /// ミニゲームのゲームオーバー処理（針に当たったときに呼ぶ）
    /// </summary>
    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;

        // GAME OVER パネル表示
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // プレイヤーの動きを止める
        if (playerRb != null)
        {
            playerRb.velocity = Vector2.zero;
        }

        if (playerJump != null)
        {
            playerJump.enabled = false;
        }
    }

    /// <summary>
    /// ミニゲームだけをリトライ（フェードイン完了時に FadeManager から呼ぶ）
    /// </summary>
    public void RestartMiniGame()
    {
        // ゲームオーバーフラグ解除
        IsGameOver = false;

        // GAME OVER UI を消す
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        // プレイヤーを初期位置に戻す
        if (player != null)
        {
            player.position = playerStartPos;
        }

        if (playerRb != null)
        {
            playerRb.velocity = Vector2.zero;
        }

        if (playerJump != null)
        {
            playerJump.enabled = true;
        }

        // 針を全消し＋タイマーリセット
        if (spikeSpawner != null)
        {
            spikeSpawner.ResetSpikes();
        }

        // ポーズ状態自体は FadeManager 側の alpha によって自動制御されるので
        // ここでは IsPaused は触らない
    }

    /// <summary>
    /// フェード中などでミニゲームを一時停止したいときに呼ぶ
    /// （FadeManager.UpdateAlpha から呼び出し）
    /// </summary>
    public void SetPaused(bool paused)
    {
        IsPaused = paused;
    }
}
