using UnityEngine;
using UnityEngine.UI;

public class ImageClickHandler : MonoBehaviour
{
    public Image imageToDisplay; // �\������摜
    public GameObject targetPanel; // �Ώۂ̃p�l��

    public void OnMouseDown()
    {
        // �摜���p�l���ɕ\��
        imageToDisplay.transform.SetParent(targetPanel.transform, false);
    }
}
