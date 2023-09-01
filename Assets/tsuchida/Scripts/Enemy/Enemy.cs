using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [NonSerialized]public EnemyHp enemyHP;

    public static Action OnReachedGoal;

    //移動速度設定用
    [SerializeField] private float setMoveSpeed = 40f;
    //移動速度
    private float moveSpeed;

    [NonSerialized] public Movepoint movepoint;
    //向かうポイントの番号
    private int currentMovepointIndex;

    //CurrentPointPositionが行われるたびに後半の処理が行われる
    public Vector3 CurrentPointPosition => movepoint.GetMovePointPosition(currentMovepointIndex);

    void Start()
    {
        enemyHP = GetComponent<EnemyHp>();
        // 向かうポイントを設定
        currentMovepointIndex = 0;
        //移動速度の設定
        SetMoveSpeed();
        //指定のコンポーネントがついているオブジェクトを探して格納する
        //movepoint = FindObjectOfType<Movepoint>().GetComponent<Movepoint>();
    }

    void Update()
    {
        Move();
        //現在の目的のポイントに到達しているかの判定
        if (NextPointReached())
        {
            //次の目的ポイントに更新する
            UpdatePointIndex();

        }
    }

    public void SetMoveSpeed()
    {
        moveSpeed = setMoveSpeed;
    }

    private void Move()
    {
        //ポジションを移動
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, moveSpeed * Time.deltaTime);
    }
    private void UpdatePointIndex()
    {
        //最終地点でなければ目標ポイントを更新する
        if (currentMovepointIndex < movepoint.points.Length - 1)
        {
            currentMovepointIndex++;

        }
    }
    private bool NextPointReached()
    {
        //次のポイントまでの残りの距離を変数に格納
        float distance = (transform.position - CurrentPointPosition).magnitude;

        //判定
        if (distance < 0.1)
        {
            return true;
        }
        return false;
    }

    public void ResetMovePoint()
    {
        currentMovepointIndex = 0;
    }
}