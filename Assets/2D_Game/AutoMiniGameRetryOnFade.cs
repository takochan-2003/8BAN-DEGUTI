using UnityEngine;
using UnityEngine.UI;

public class AutoMiniGameRetryOnFade : MonoBehaviour
{
    [Tooltip("フェードインに使っている Image")]
    public Image fadeImage;

    // 一度だけ実行するためのフラグ
    private bool hasTriggered = false;

    // アルファを 0 とみなす閾値
    public float alphaThreshold = 0.01f;

    void Reset()
    {
        // コンポーネントを追加したときに自動で Image を拾う用
        if (fadeImage == null)
            fadeImage = GetComponent<Image>();
    }

    void Update()
    {
        if (hasTriggered) return;
        if (fadeImage == null) return;

        float a = fadeImage.color.a;

        // まだ完全に透明になっていないなら何もしない
        if (a > alphaThreshold)
            return;

        // ここに来た = フェードイン完了タイミング
        hasTriggered = true;

        // ミニゲームがゲームオーバーだったらリトライ
        if (MiniGameManager.Instance != null &&
            MiniGameManager.Instance.IsGameOver)
        {
            MiniGameManager.Instance.RestartMiniGame();
        }
    }
}
