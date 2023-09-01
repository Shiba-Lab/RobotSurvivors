using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [NonSerialized]public EnemyHp enemyHP;

    public static Action OnReachedGoal;

    //�ړ����x�ݒ�p
    [SerializeField] private float setMoveSpeed = 40f;
    //�ړ����x
    private float moveSpeed;

    [NonSerialized] public Movepoint movepoint;
    //�������|�C���g�̔ԍ�
    private int currentMovepointIndex;

    //CurrentPointPosition���s���邽�тɌ㔼�̏������s����
    public Vector3 CurrentPointPosition => movepoint.GetMovePointPosition(currentMovepointIndex);

    void Start()
    {
        enemyHP = GetComponent<EnemyHp>();
        // �������|�C���g��ݒ�
        currentMovepointIndex = 0;
        //�ړ����x�̐ݒ�
        SetMoveSpeed();
        //�w��̃R���|�[�l���g�����Ă���I�u�W�F�N�g��T���Ċi�[����
        //movepoint = FindObjectOfType<Movepoint>().GetComponent<Movepoint>();
    }

    void Update()
    {
        Move();
        //���݂̖ړI�̃|�C���g�ɓ��B���Ă��邩�̔���
        if (NextPointReached())
        {
            //���̖ړI�|�C���g�ɍX�V����
            UpdatePointIndex();

        }
    }

    public void SetMoveSpeed()
    {
        moveSpeed = setMoveSpeed;
    }

    private void Move()
    {
        //�|�W�V�������ړ�
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition, moveSpeed * Time.deltaTime);
    }
    private void UpdatePointIndex()
    {
        //�ŏI�n�_�łȂ���ΖڕW�|�C���g���X�V����
        if (currentMovepointIndex < movepoint.points.Length - 1)
        {
            currentMovepointIndex++;

        }
    }
    private bool NextPointReached()
    {
        //���̃|�C���g�܂ł̎c��̋�����ϐ��Ɋi�[
        float distance = (transform.position - CurrentPointPosition).magnitude;

        //����
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