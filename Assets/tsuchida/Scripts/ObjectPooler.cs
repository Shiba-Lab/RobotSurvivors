using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //��������A�C�e��
    [SerializeField] private GameObject poolObject;
    //�������鐔
    [SerializeField] private int poolSize = 10;
    //���������I�u�W�F�N�g���Ǘ����郊�X�g
    private List<GameObject> pool;
    //�e�I�u�W�F�N�g���i�[���Ă���
    private GameObject poolContainer;

    private void Awake()
    {
        //�C���X�^���X��
        pool = new List<GameObject>();
        //�I�u�W�F�N�g�𐶐����Ė��O��t���ĕϐ��Ɋi�[
        poolContainer = new GameObject($"Pool - {poolObject.name}");
        //�v�[���I�u�W�F�N�g�̍쐬
        CreatePooler();
    }

    /// <summary>
    /// poolSize�̐�poolObject�𐶐�����
    /// </summary>
    private void CreatePooler()
    {
        //poolsize�̕����[�v
        for (int i = 0; i < poolSize; i++)
        {
            //���������I�u�W�F�N�g�����X�g�Ɋi�[
            pool.Add(CreateObject());

        }
    }

    /// <summary>
    /// poolobject�𐶐����ČĂ񂾏ꏊ�ɕԂ�
    /// </summary>
    /// <returns></returns>
    private GameObject CreateObject()
    {
        //�I�u�W�F�N�g���쐬���ĕϐ��Ɋi�[����
        GameObject newInstance = Instantiate(poolObject);

        //�e�̐ݒ�
        newInstance.transform.SetParent(poolContainer.transform);


        //��\��
        newInstance.SetActive(false);

        //�Ԃ�
        return newInstance;
    }

    /// <summary>
    /// �v�[������I�u�W�F�N�g�������o��
    /// </summary>
    /// <returns></returns>
    public GameObject GetObjectFromPool()
    {
        //���X�g�Ɋi�[����Ă��镪���[�v����
        for (int i = 0; i < pool.Count; i++)
        {
            //�����v�[�����̔�\���I�u�W�F�N�g��������
            if (!pool[i].activeInHierarchy)
            {
                //�Ăяo�����ꏊ�ɕԂ�
                return pool[i];

            }

        }

        //����Ȃ���ΐ������ĕԂ�
        return CreateObject();

    }

    /// <summary>
    /// �v�[���ɃI�u�W�F�N�g��ԋp
    /// </summary>
    /// <param name="instance"></param>
    public static void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
    }

}