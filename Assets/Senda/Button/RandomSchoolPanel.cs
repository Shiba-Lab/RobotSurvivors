using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSchoolPanel : MonoBehaviour
{
    public string sceneAName; // シーンAの名前をInspectorでアタッチ
    public string sceneBName; // シーンBの名前をInspectorでアタッチ

    public void OnClickPanel()
    {
        float randomValue = Random.value; // 0～1のランダムな値を取得

        if (randomValue < 0.5f)
        {
            SceneManager.LoadScene(sceneAName); // 50％の確率でシーンAに遷移
        }
        else
        {
            SceneManager.LoadScene(sceneBName); // 50％の確率でシーンBに遷移
        }
    }
}

