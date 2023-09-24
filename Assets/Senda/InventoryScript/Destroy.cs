using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    private GameObject[] objectsToKeep; // �����p���I�u�W�F�N�g��ۑ�����z��

    public void SwitchToNewScene(string sceneName)
    {
        // �O�̃V�[����������p���I�u�W�F�N�g��ۑ�
        objectsToKeep = GameObject.FindGameObjectsWithTag("YourTag");

        // �V�����V�[���ɑJ��
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToPreviousScene()
    {
        // �V�����V�[���Ő������ꂽ�I�u�W�F�N�g���폜
        foreach (GameObject obj in objectsToKeep)
        {
            Destroy(obj);
        }

        // ���̃V�[���ɖ߂�
        SceneManager.LoadScene("YourPreviousSceneName");
    }
}
