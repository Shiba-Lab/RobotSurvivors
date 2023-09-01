using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movepoint : MonoBehaviour
{
    public Vector3[] points;

    //エディタ上で見えるようにする
    private void OnDrawGizmos()
    {
        //for文で配列の数値分処理する
        for (int i = 0; i < points.Length; i++)
        {
            //色を指定
            Gizmos.color = Color.yellow;

            //ポジション、半径
            Gizmos.DrawWireSphere(points[i], 10f);
        }
    }

    /// <summary>
    /// 引数で渡された数値と同じポイントの位置を返す
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector3 GetMovePointPosition(int index)
    {
        //敵の移動に必要
        return points[index];

    }
}
