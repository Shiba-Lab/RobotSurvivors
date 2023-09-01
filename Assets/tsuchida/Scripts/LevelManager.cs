using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [NonSerialized] public int currentWave;
    //実際に値を変更させる体力変数
    [NonSerialized] public int currentLife;
    //体力の初期設定だけに使う数値
    [SerializeField] private int life = 10;


    //シングルトンにする
    public static LevelManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //現在のウェーブを設定する
        currentWave = 1;
        //体力を設定
        currentLife = life;
    }

    private void WaveCompleted()
    {
        currentWave++;

    }

    //private void OnEnable()
    //{
    //    Spawner.OnWaveCompleted += WaveCompleted;
    //    Enemy.OnReachedGoal += ReduceLifes;
    //}

    //private void OnDisable()
    //{
    //    Spawner.OnWaveCompleted -= WaveCompleted;
    //    Enemy.OnReachedGoal += ReduceLifes;
    //}

    /// <summary>
    /// ライフを減らして体力を確認する
    /// </summary>
    private void ReduceLifes()
    {
        currentLife--;

        //体力が0になっていないか
        if (currentLife <= 0)
        {
            currentLife = 0;
            //ゲームオーバー
            Debug.Log("ゲームオーバー");

        }

    }
}