using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [NonSerialized] public int currentWave;
    //���ۂɒl��ύX������̗͕ϐ�
    [NonSerialized] public int currentLife;
    //�̗͂̏����ݒ肾���Ɏg�����l
    [SerializeField] private int life = 10;


    //�V���O���g���ɂ���
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
        //���݂̃E�F�[�u��ݒ肷��
        currentWave = 1;
        //�̗͂�ݒ�
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
    /// ���C�t�����炵�đ̗͂��m�F����
    /// </summary>
    private void ReduceLifes()
    {
        currentLife--;

        //�̗͂�0�ɂȂ��Ă��Ȃ���
        if (currentLife <= 0)
        {
            currentLife = 0;
            //�Q�[���I�[�o�[
            Debug.Log("�Q�[���I�[�o�[");

        }

    }
}