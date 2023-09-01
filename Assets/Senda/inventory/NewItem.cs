using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Create Item")]
public class Item : ScriptableObject
{
    //�A�C�e���̖��O
    new public string name = "New Item";
    //�A�C�e���̃A�C�R��
    public Sprite icon = null;

    //�A�C�e���̎g�p
    public void Use()
    {
        Debug.Log(name + "���g�p���܂���");

    }
}