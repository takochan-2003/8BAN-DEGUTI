using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [Header("説明画像表示用")]
    public Image explanationImage;        // 表示するImage
    public Sprite[] explanationSprites;   // 説明画像5枚

    private int currentIndex = 0;

    void Start()
    {
        // 最初の説明画像を表示
        explanationImage.sprite = explanationSprites[currentIndex];
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentIndex++;

            // まだ説明画像が残っている場合
            if (currentIndex < explanationSprites.Length)
            {
                explanationImage.sprite = explanationSprites[currentIndex];
            }
            else
            {
                // 全部見終わったら次のシーンへ
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}

