using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Transform _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) _player.MoveLeft();
        if (Input.GetKey(KeyCode.D)) _player.MoveRight();
    }
}
