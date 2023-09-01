using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movepoint : MonoBehaviour
{
    public Vector3[] points;

    //�G�f�B�^��Ō�����悤�ɂ���
    private void OnDrawGizmos()
    {
        //for���Ŕz��̐��l����������
        for (int i = 0; i < points.Length; i++)
        {
            //�F���w��
            Gizmos.color = Color.yellow;

            //�|�W�V�����A���a
            Gizmos.DrawWireSphere(points[i], 10f);
        }
    }

    /// <summary>
    /// �����œn���ꂽ���l�Ɠ����|�C���g�̈ʒu��Ԃ�
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetMovePointPosition(int index)
    {
        //�G�̈ړ��ɕK�v
        return points[index];

    }
}
