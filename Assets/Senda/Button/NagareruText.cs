using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    public float letterDelay = 0.1f; // 1����������̒x��

    private string originalText;
    private string displayedText = "";
    private float timer = 0f;
    private int currentLetterIndex = 0;

    private void Start()
    {
        originalText = textMeshProText.text;
        textMeshProText.text = ""; // �ŏ��͋�ɂ���
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= letterDelay && currentLetterIndex < originalText.Length)
        {
            displayedText += originalText[currentLetterIndex];
            textMeshProText.text = displayedText;

            currentLetterIndex++;
            timer = 0f;
        }
    }
}

