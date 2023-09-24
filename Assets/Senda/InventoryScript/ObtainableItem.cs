// アイテムのクラス
using UnityEngine;

public class ObtainableItem : MonoBehaviour
{
    [SerializeField] Obtainable obt; // 取得可能クラスのオブジェクト

    // アイテムに触った時
    public void ClickObject()
    {
        obt.Obtain(gameObject); // 取得メソッドを呼ぶ
    }

    

}