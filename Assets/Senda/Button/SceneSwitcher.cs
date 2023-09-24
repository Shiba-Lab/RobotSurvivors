using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName; // ターゲットとなるシーンの名前をインスペクターで設定

    public void SwitchToTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}