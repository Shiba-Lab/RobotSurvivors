using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Player : MonoBehaviour
//{
//    public float movespeed = 0.5f;
//    public float hp = 3f;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        float fHorizontalInput = Input.GetAxisRaw("Horizontal");
//        float fVerticalInput = Input.GetAxis("Vertical");

//        float add_x = fHorizontalInput * movespeed;
//        float add_y = fVerticalInput * movespeed;
//        //transform.position = new Vector3(transform.position.x + add_x,transform.position.y +  add_y, 0);
//        transform.Translate(add_x, add_y, 0);
//    }
//}

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - speed, transform.position.y);
    }
    public void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y);
    }
}