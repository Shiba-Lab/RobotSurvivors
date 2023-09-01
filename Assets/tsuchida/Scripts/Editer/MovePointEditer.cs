using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Movepoint))]
public class MovePointEditer : Editor
{
    //�ϐ��Ɋi�[����
    Movepoint movepoint => target as Movepoint;

    [System.Obsolete]
    private void OnSceneGUI()
    {
        //�F���w��
        Handles.color = Color.yellow;

        for (int i = 0; i < movepoint.points.Length; i++)
        {
            //EndChangeCheck�Ƃ̊ԂŃV�[�����ł̕ω����Ȃ��̂��m�F����
            EditorGUI.BeginChangeCheck();
            //�|�C���g�̈ʒu���擾
            Vector3 currentWaypoint = movepoint.points[i];

            //�n���h���𐶐����ĕϐ��Ɋi�[����
            Vector3 newWaypoint = Handles.FreeMoveHandle
                (currentWaypoint, Quaternion.identity, 10f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

            //�n���h���ԍ��̐���
            GUIStyle textStyle = new GUIStyle();
            textStyle.fontSize = 18;
            textStyle.normal.textColor = Color.white;
            Vector3 textPos = Vector3.down * 0.35f + Vector3.right * 0.35f;

            //���x���̔����ʒu�A�\�����e�AGUI�̐ݒ�
            Handles.Label(movepoint.points[i] + textPos, $"{i + 1}", textStyle);

            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                //�ʒu�̕ۑ�CTRL+Z�Ŗ߂���悤�ɂ���
                Undo.RecordObject(target, "Move");

                //���������n���h���ʒu�ɕύX����
                movepoint.points[i] = newWaypoint;
            }

        }
    }
}