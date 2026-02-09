using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private float speed = 0.4f; // フェードのスピード
    private float alpha;

    public bool isFadingOut = false;
    public bool isFadingIn = false;

    private Image fadeImage;

    public System.Action onFadeInComplete;  // フェードイン完了時のコールバック
    public System.Action onFadeOutComplete; // フェードアウト完了時のコールバック

    // ★追加：BGM
    [Header("BGM")]
    public AudioSource bgmSource;
    public float alphaThreshold = 0.01f; // ほぼ透明扱い

    void Start()
    {
        fadeImage = GetComponent<Image>();
        if (fadeImage == null)
        {
            Debug.LogError("FadeManager: Image component not found!");
            return;
        }

        fadeImage.enabled = true; // 起動時にパネルを表示
        alpha = 1.0f;             // フェードイン用の初期状態
        UpdateAlpha();
        StartFadeIn();            // シーン開始時にフェードイン

        Debug.Log("Fade Start alpha=" + alpha);
    }

    void Update()
    {
        if (isFadingIn)
        {
            FadeIn();
        }
        else if (isFadingOut)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        alpha -= speed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        UpdateAlpha();

        if (alpha <= 0f)
        {
            isFadingIn = false;
            fadeImage.enabled = false; // 完了後に非表示

            // ▼ ここでコールバック
            onFadeInComplete?.Invoke();

            // ▼ ミニゲームがゲームオーバーならリトライ
            if (MiniGameManager.Instance != null &&
                MiniGameManager.Instance.IsGameOver)
            {
                MiniGameManager.Instance.RestartMiniGame();
            }
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true; // フェードアウト時に画像を表示
        alpha += speed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        UpdateAlpha();

        if (alpha >= 1f)
        {
            isFadingOut = false;
            onFadeOutComplete?.Invoke();
        }
    }

    void UpdateAlpha()
    {
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = alpha;
            fadeImage.color = color;
        }

        // ★ここだけ差し替えでOK
        if (bgmSource != null)
        {
            bool isDark = alpha > alphaThreshold;

            if (isDark)
            {
                // 暗転中は止める
                if (bgmSource.isPlaying) bgmSource.Stop();
            }
            else
            {
                // 明るくなったら再生開始（確実に鳴る）
                if (!bgmSource.isPlaying) bgmSource.Play();
            }
        }

        // ★ 追加：フェード中はミニゲームを一時停止
        if (MiniGameManager.Instance != null)
        {
            // 「ほぼ透明」を許容したければ 0.01f とかにしてもOK
            bool paused = alpha > 0f;
            MiniGameManager.Instance.SetPaused(paused);
        }
    }

    public void StartFadeIn()
    {
        isFadingIn = true;
        fadeImage.enabled = true;
    }

    public void StartFadeOut()
    {
        isFadingOut = true;
        fadeImage.enabled = true;
    }
}
