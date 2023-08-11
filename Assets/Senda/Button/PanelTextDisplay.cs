using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject panel; // UI Panel��Inspector�ŃA�^�b�`
    public Text textComponent; // UI Text��Inspector�ŃA�^�b�`
    public string displayText = "Hello, World!"; // �\������e�L�X�g��Inspector�Őݒ�
    public float textSpeed = 0.5f; // �e�L�X�g�\�����x

    private string currentText = "";
    private int currentIndex = 0;
    private bool isDisplayingText = false;

    private void Start()
    {
        panel.SetActive(false); // �ŏ��̓p�l�����\���ɂ���
    }

    public void OnButtonClick()
    {
        panel.SetActive(true); // �p�l����\������
        currentText = displayText;
        currentIndex = 0;
        isDisplayingText = true;
        textComponent.text = ""; // �����\�����̓e�L�X�g���N���A
    }

    private void Update()
    {
        if (isDisplayingText && currentIndex < currentText.Length)
        {
            textComponent.text += currentText[currentIndex];
            currentIndex++;
            Invoke("UpdateText", textSpeed); // ���̕����\�����X�P�W���[��
        }
    }
}
