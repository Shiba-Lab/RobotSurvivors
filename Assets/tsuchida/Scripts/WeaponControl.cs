using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponControl : MonoBehaviour
{
    //�e�𐶐�����ʒu
    [SerializeField] private Transform bulletSpawnPos;
    //�U���������̒e
    private Bullet currentBullet;
    //������i�[
    private Gun gun;
    //�C���X�y�N�^�[�ŕύX�\�Ȓe�_���[�W,�e�̊�b�_���[�W�Ƃ��Ĉ���
    [SerializeField] private float damage = 2f;
    //���ۂ̓����e�_���[�W
    [NonSerialized] private float bulletDamege;
    //���������e���i�[
    public GameObject bullet;

    private void Start()
    {
        
    }
}
