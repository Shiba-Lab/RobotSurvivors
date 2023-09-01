using UnityEngine;
using UnityEngine.UI;

public class ImageClickHandler : MonoBehaviour
{
    public Image imageToDisplay; // 表示する画像
    public GameObject targetPanel; // 対象のパネル

    public void OnMouseDown()
    {
        // 画像をパネルに表示
        imageToDisplay.transform.SetParent(targetPanel.transform, false);
    }
}
