using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MouseHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI hoverText; // ホバーテキストをInspectorでアタッチ

    void Start()
    {
        hoverText.gameObject.SetActive(false); // ホバーテキストを非表示にする
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverText.gameObject.SetActive(true); // ホバーテキストを表示する
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverText.gameObject.SetActive(false); // ホバーテキストを非表示にする
    }
}

