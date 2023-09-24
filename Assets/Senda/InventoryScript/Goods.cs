using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goods : MonoBehaviour
{
    GameObject itemObject;
    string itemName;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetUp(Obtainable item)
    {
        image = GetComponent<Image>(); // Image�R���|�[�l���g

        this.itemName = item.GetItemName(); // �A�C�e�������擾

        // �摜���擾����Image�R���|�[�l���g�ɓ����
        image.sprite = ItemManager.GetInstance().GetItem(this.itemName).GetIcon();
        this.itemObject = item.GetGameObject(); // �I�u�W�F�N�g���擾
    }

}