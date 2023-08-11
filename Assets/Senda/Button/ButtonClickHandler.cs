using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    
    public GameObject ObjectToHide;   // 非表示にするパネルをInspectorでアタッチ

    public void OnButtonClick()
    {
        
      ObjectToHide.SetActive(false);
        
    }
}

