using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    
    public GameObject ObjectToHide;   // ��\���ɂ���p�l����Inspector�ŃA�^�b�`

    public void OnButtonClick()
    {
        
      ObjectToHide.SetActive(false);
        
    }
}

