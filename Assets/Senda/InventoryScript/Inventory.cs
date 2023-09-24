using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject imagePrefab;
    List<Goods> inventory = new List<Goods>();

    static Inventory instance;
    public static Inventory GetInstance()
    {
        return instance;
    }

    // �A�C�e�����擾���郁�\�b�h
    public void Obtain(Obtainable item)
    {
        // �A�C�e���̑��݂��m�F
        if (ItemManager.GetInstance().HasItem(item.GetItemName()))
        {
            GameObject goodsObj = Instantiate(imagePrefab, content); // Image�C���X�^���X�����
            Goods goods = goodsObj.GetComponent<Goods>(); // �X�N���v�g���擾
            goods.SetUp(item); // �摜�Ȃǂ�ݒ�
            item.GetGameObject().SetActive(false); // �A�C�e�����A�N�e�B�u�ɂ���
            inventory.Add(goods); // ���X�g�ɓ����

            
        }
        else
        {
            
        }
    }
    private void Awake()
    {
        instance = this;
    }

}