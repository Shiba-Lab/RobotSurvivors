using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    //設定用のHP
    [SerializeField] private float hp = 10;
    //現在のHP
    [NonSerialized] public float currentHp;
    //HPを表示するUI
    [SerializeField] private GameObject hpBar;
    //HPバーのポジション
    [SerializeField] private Transform barPoz;

    private Image hpBarImage;

    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
    }

    private void CreateHealthBar()
    {
        //生成して親オブジェクトを設定する
        GameObject newBar = Instantiate(hpBar, barPoz.position, Quaternion.identity);
        newBar.transform.SetParent(transform);
        //newBarから変数にHPバーを格納する
        EnemyHpBar healthBar = newBar.GetComponent<EnemyHpBar>();
        //画像を変数に格納する
        hpBarImage = healthBar.hpBarImage;
        //HPを更新する
        currentHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        //クリックしたらダメージを受ける
        if (Input.GetMouseButtonDown(0))
        {
            ReduceHP(5);
        }
        //HPバーの表示を更新する
        hpBarImage.fillAmount = Mathf.Lerp(hpBarImage.fillAmount, currentHp / hp, Time.deltaTime * 10f);
    }

    /// <summary>
    /// HPを減らす
    /// </summary>
    /// <param name="damage"></param>
    public void ReduceHP(float damage)
    {
        currentHp -= damage;

        //死んでいるかの判定
        DeathCheck();

    }

    /// <summary>
    /// HPが0になっているかのチェック
    /// </summary>
    private void DeathCheck()
    {
        if (currentHp <= 0)
        {
            currentHp = 0;

            //非表示にする
            gameObject.SetActive(false);

        }
    }
}
