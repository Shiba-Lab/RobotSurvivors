using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponControl : MonoBehaviour
{
    //弾を生成する位置
    [SerializeField] private Transform bulletSpawnPos;
    //攻撃準備中の弾
    private Bullet currentBullet;
    //武器を格納
    private Gun gun;
    //インスペクターで変更可能な弾ダメージ,弾の基礎ダメージとして扱う
    [SerializeField] private float damage = 2f;
    //実際の内部弾ダメージ
    [NonSerialized] private float bulletDamege;
    //生成した弾を格納
    public GameObject bullet;

    private void Start()
    {
        
    }
}
