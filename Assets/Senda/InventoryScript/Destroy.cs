using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    private GameObject[] objectsToKeep; // 引き継ぐオブジェクトを保存する配列

    public void SwitchToNewScene(string sceneName)
    {
        // 前のシーンから引き継ぐオブジェクトを保存
        objectsToKeep = GameObject.FindGameObjectsWithTag("YourTag");

        // 新しいシーンに遷移
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToPreviousScene()
    {
        // 新しいシーンで生成されたオブジェクトを削除
        foreach (GameObject obj in objectsToKeep)
        {
            Destroy(obj);
        }

        // 元のシーンに戻る
        SceneManager.LoadScene("YourPreviousSceneName");
    }
}
