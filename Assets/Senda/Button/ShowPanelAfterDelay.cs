using UnityEngine;

public class ShowPanelAfterDelay : MonoBehaviour
{
    public GameObject panel; // �\������p�l����Inspector�ŃA�^�b�`
    public float delayInSeconds = 3.0f; // �\���܂ł̒x�����ԁi�b�j

    private float timer = 0f;
    private bool hasShownPanel = false;

    private void Update()
    {
        if (!hasShownPanel)
        {
            timer += Time.deltaTime;

            if (timer >= delayInSeconds)
            {
                panel.SetActive(true); // �p�l�����A�N�e�B�u�ɂ���
                hasShownPanel = true;
            }
        }
    }
}

