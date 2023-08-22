using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSchoolPanel : MonoBehaviour
{
    public string sceneAName; // �V�[��A�̖��O��Inspector�ŃA�^�b�`
    public string sceneBName; // �V�[��B�̖��O��Inspector�ŃA�^�b�`

    public void OnClickPanel()
    {
        float randomValue = Random.value; // 0�`1�̃����_���Ȓl���擾

        if (randomValue < 0.5f)
        {
            SceneManager.LoadScene(sceneAName); // 50���̊m���ŃV�[��A�ɑJ��
        }
        else
        {
            SceneManager.LoadScene(sceneBName); // 50���̊m���ŃV�[��B�ɑJ��
        }
    }
}

