using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName; // �^�[�Q�b�g�ƂȂ�V�[���̖��O���C���X�y�N�^�[�Őݒ�

    public void SwitchToTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}