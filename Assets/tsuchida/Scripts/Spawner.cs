using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スポーンモード
public enum Spawnmodes
{
    constant,//一定間隔でスポーンする
    Random,//ランダムにスポーンする

}

public class Spawner : MonoBehaviour
{

    //スポーンモードの選択
    [SerializeField] private Spawnmodes spawnModes = Spawnmodes.constant;
    //最短のスポーン間隔
    [SerializeField] private float minRandomDelay;
    //最長のスポーン間隔
    [SerializeField] private float maxRandomDelay;
    //一定モードのスポーン時間
    [SerializeField] private float constantSpawnTime;
    //スポーンさせる数を設定する
    [SerializeField] private int enemyCount = 10;
    //タイマー変数
    private float spawnTimer;
    //スポーンさせた数（数を追加していく）
    private float spawned;
    //enemyのオブジェクトプール用
    private ObjectPooler pooler;
    //MovePoint格納用　Enemyに渡すためにここに格納する
    private Movepoint movePoint;
    //生成できる敵の数
    private int enemiesRemaining;
    //ウェーブの遅延
    [SerializeField] private float waveDelayTime = 1f;
    //ウェーブ達成時に呼ばれるアクション
    public static Action OnWaveCompleted;

    private void Start()
    {
        //生成できる数を設定する
        enemiesRemaining = enemyCount;
        //変数にコンポーネントを格納する
        pooler = GetComponent<ObjectPooler>();
        movePoint = GetComponent<Movepoint>();
    }

    private void Update()
    {
        //spawnタイマーの時間を減らす
        spawnTimer -= Time.deltaTime;
        //確認
        if (spawnTimer < 0)
        {
            spawnTimer = GetSpawnDelay();

            //スポーン上限の確認
            if (spawned < enemyCount)
            {
                //生成済みの数を追加
                spawned++;

                //敵を生成
                SpawnEnemy();

            }
        }
    }

    /// <summary>
    /// 敵を生成する
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void SpawnEnemy()
    {
        //プールから取得して変数に格納
        GameObject newInstance = pooler.GetObjectFromPool();
        //エネミーの初期設定
        SetEnemy(newInstance);
        //表示する
        newInstance.SetActive(true);
    }

    private void SetEnemy(GameObject newInstance)
    {
        //enemyでMovepointを使えるように格納している
        Enemy enemy = newInstance.GetComponent<Enemy>();
        enemy.ResetMovePoint();
        enemy.movepoint = movePoint;
        //生成位置をこのオブジェクトの位置に設定
        enemy.transform.position = transform.position;
        //スピードの設定
        enemy.SetMoveSpeed();

    }

    /// <summary>
    /// 一定もしくはランダムの数値を返す
    /// </summary>
    /// <returns></returns>
    private float GetSpawnDelay()
    {
        if (spawnModes == Spawnmodes.constant)
        {
            return constantSpawnTime;
        }
        else
        {
            //引数の間からランダムな数値を選んで返す
            return UnityEngine.Random.Range(minRandomDelay, maxRandomDelay);

        }
    }

    /// </summary>
    private void RecordEnemy()
    {
        //このウェーブで生存している敵の数
        enemiesRemaining--;
        //このウェーブの完了条件を確認する
        CurrentWeaveCheck();

    }

    /// <summary>
    /// ウェーブの完了条件を確認して、イベントとコルーチンを呼ぶ
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void CurrentWeaveCheck()
    {
        if (enemiesRemaining <= 0)
        {
            //ウェーブ完了時の処理を呼び出す
            OnWaveCompleted?.Invoke();
            //次のウェーブの準備
            StartCoroutine(NextWave());
        }
    }
    /// <summary>
    /// 次のウェーブに向けて数値関係をリセット
    /// </summary>
    /// <returns></returns>
    private IEnumerator NextWave()
    {
        //数値の分待機する
        yield return new WaitForSeconds(waveDelayTime);
        //生成する敵の数をセット
        enemiesRemaining = enemyCount;
        //次のスポーンまでの時間
        spawnTimer = 0f;
        //生成した後
        spawned = 0;

    }

    //private void OnEnable()
    //{
    //    //イベントに関数を登録
    //    Enemy.OnReachedGoal += RecordEnemy;
    //    //EnemyHP.OnEnemyDead += RecordEnemy;
    //}

    //private void OnDisable()
    //{
    //    //イベントから関数を消去
    //    Enemy.OnReachedGoal -= RecordEnemy;
    //    //EnemyHP.OnEnemyDead -= RecordEnemy;
    //}
}
