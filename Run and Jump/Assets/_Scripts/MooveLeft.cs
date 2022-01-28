using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveLeft : MonoBehaviour
{

    public float speed = 5;

    private PlayerController _playerContoller;

    private void Start()
    {
        _playerContoller = GameObject.Find("Player").//GameObject
            GetComponent<PlayerController>(); //PlayerController
    }
    // Update is called once per frame
    void Update()
    {
        if(!_playerContoller.GameOver)
        {
            _playerContoller.GameOver = false;
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       
    }
}
