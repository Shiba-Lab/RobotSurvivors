using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject panel; // UI PanelをInspectorでアタッチ
    public Text textComponent; // UI TextをInspectorでアタッチ
    public string displayText = "Hello, World!"; // 表示するテキストをInspectorで設定
    public float textSpeed = 0.5f; // テキスト表示速度

    private string currentText = "";
    private int currentIndex = 0;
    private bool isDisplayingText = false;

    private void Start()
    {
        panel.SetActive(false); // 最初はパネルを非表示にする
    }

    public void OnButtonClick()
    {
        panel.SetActive(true); // パネルを表示する
        currentText = displayText;
        currentIndex = 0;
        isDisplayingText = true;
        textComponent.text = ""; // 初期表示時はテキストをクリア
    }

    private void Update()
    {
        if (isDisplayingText && currentIndex < currentText.Length)
        {
            textComponent.text += currentText[currentIndex];
            currentIndex++;
            Invoke("UpdateText", textSpeed); // 次の文字表示をスケジュール
        }
    }
}
