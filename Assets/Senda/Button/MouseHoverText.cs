using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MouseHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hoverText; // �z�o�[�e�L�X�g��Inspector�ŃA�^�b�`

    void Start()
    {
        hoverText.gameObject.SetActive(false); // �z�o�[�e�L�X�g���\���ɂ���
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.gameObject.SetActive(true); // �z�o�[�e�L�X�g��\������
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.gameObject.SetActive(false); // �z�o�[�e�L�X�g���\���ɂ���
    }
}

