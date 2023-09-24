using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�|�[�����[�h
public enum Spawnmodes
{
    constant,//���Ԋu�ŃX�|�[������
    Random,//�����_���ɃX�|�[������

}

public class Spawner : MonoBehaviour
{

    //�X�|�[�����[�h�̑I��
    [SerializeField] private Spawnmodes spawnModes = Spawnmodes.constant;
    //�ŒZ�̃X�|�[���Ԋu
    [SerializeField] private float minRandomDelay;
    //�Œ��̃X�|�[���Ԋu
    [SerializeField] private float maxRandomDelay;
    //��胂�[�h�̃X�|�[������
    [SerializeField] private float constantSpawnTime;
    //�X�|�[�������鐔��ݒ肷��
    [SerializeField] private int enemyCount = 10;
    //�^�C�}�[�ϐ�
    private float spawnTimer;
    //�X�|�[�����������i����ǉ����Ă����j
    private float spawned;
    //enemy�̃I�u�W�F�N�g�v�[���p
    private ObjectPooler pooler;
    //MovePoint�i�[�p�@Enemy�ɓn�����߂ɂ����Ɋi�[����
    private Movepoint movePoint;
    //�����ł���G�̐�
    private int enemiesRemaining;
    //�E�F�[�u�̒x��
    [SerializeField] private float waveDelayTime = 1f;
    //�E�F�[�u�B�����ɌĂ΂��A�N�V����
    public static Action OnWaveCompleted;

    private void Start()
    {
        //�����ł��鐔��ݒ肷��
        enemiesRemaining = enemyCount;
        //�ϐ��ɃR���|�[�l���g���i�[����
        pooler = GetComponent<ObjectPooler>();
        movePoint = GetComponent<Movepoint>();
    }

    private void Update()
    {
        //spawn�^�C�}�[�̎��Ԃ����炷
        spawnTimer -= Time.deltaTime;
        //�m�F
        if (spawnTimer < 0)
        {
            spawnTimer = GetSpawnDelay();

            //�X�|�[������̊m�F
            if (spawned < enemyCount)
            {
                //�����ς݂̐���ǉ�
                spawned++;

                //�G�𐶐�
                SpawnEnemy();

            }
        }
    }

    /// <summary>
    /// �G�𐶐�����
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void SpawnEnemy()
    {
        //�v�[������擾���ĕϐ��Ɋi�[
        GameObject newInstance = pooler.GetObjectFromPool();
        //�G�l�~�[�̏����ݒ�
        SetEnemy(newInstance);
        //�\������
        newInstance.SetActive(true);
    }

    private void SetEnemy(GameObject newInstance)
    {
        //enemy��Movepoint���g����悤�Ɋi�[���Ă���
        Enemy enemy = newInstance.GetComponent<Enemy>();
        enemy.ResetMovePoint();
        enemy.movepoint = movePoint;
        //�����ʒu�����̃I�u�W�F�N�g�̈ʒu�ɐݒ�
        enemy.transform.position = transform.position;
        //�X�s�[�h�̐ݒ�
        enemy.SetMoveSpeed();

    }

    /// <summary>
    /// ���������̓����_���̐��l��Ԃ�
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
            //�����̊Ԃ��烉���_���Ȑ��l��I��ŕԂ�
            return UnityEngine.Random.Range(minRandomDelay, maxRandomDelay);

        }
    }

    /// </summary>
    private void RecordEnemy()
    {
        //���̃E�F�[�u�Ő������Ă���G�̐�
        enemiesRemaining--;
        //���̃E�F�[�u�̊����������m�F����
        CurrentWeaveCheck();

    }

    /// <summary>
    /// �E�F�[�u�̊����������m�F���āA�C�x���g�ƃR���[�`�����Ă�
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void CurrentWeaveCheck()
    {
        if (enemiesRemaining <= 0)
        {
            //�E�F�[�u�������̏������Ăяo��
            OnWaveCompleted?.Invoke();
            //���̃E�F�[�u�̏���
            StartCoroutine(NextWave());
        }
    }
    /// <summary>
    /// ���̃E�F�[�u�Ɍ����Đ��l�֌W�����Z�b�g
    /// </summary>
    /// <returns></returns>
    private IEnumerator NextWave()
    {
        //���l�̕��ҋ@����
        yield return new WaitForSeconds(waveDelayTime);
        //��������G�̐����Z�b�g
        enemiesRemaining = enemyCount;
        //���̃X�|�[���܂ł̎���
        spawnTimer = 0f;
        //����������
        spawned = 0;

    }

    //private void OnEnable()
    //{
    //    //�C�x���g�Ɋ֐���o�^
    //    Enemy.OnReachedGoal += RecordEnemy;
    //    //EnemyHP.OnEnemyDead += RecordEnemy;
    //}

    //private void OnDisable()
    //{
    //    //�C�x���g����֐�������
    //    Enemy.OnReachedGoal -= RecordEnemy;
    //    //EnemyHP.OnEnemyDead -= RecordEnemy;
    //}
}
