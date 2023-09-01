using UnityEngine;

public class ShowPanelAfterDelay : MonoBehaviour
{
    public GameObject panel; // 表示するパネルをInspectorでアタッチ
    public float delayInSeconds = 3.0f; // 表示までの遅延時間（秒）

    private float timer = 0f;
    private bool hasShownPanel = false;

    private void Update()
    {
        if (!hasShownPanel)
        {
            timer += Time.deltaTime;

            if (timer >= delayInSeconds)
            {
                panel.SetActive(true); // パネルをアクティブにする
                hasShownPanel = true;
            }
        }
    }
}

