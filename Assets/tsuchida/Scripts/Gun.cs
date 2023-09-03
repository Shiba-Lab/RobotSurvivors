using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float attackRange = 3f;

    void Start()
    {
        GetComponent<CircleCollider2D>().radius = attackRange;   
    }

    private void OnDrawGizmos()
    {
        //�U���͈͂̉���
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }



    
}
