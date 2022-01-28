using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteController : MonoBehaviour
{

    private Animator _animator;

    private const string MOVE_HANDS = "Move Hands"; //constante del nombre que le hemos dado en el controlador de Unity
    private const string MOVE_X = "Move_X";
    private const string MOVE_Y = "Move_Y";
    private const string IS_MOVING = "isMoving";

    private bool isMovingHands = false, isMoving = false;

    private float moveX = 0, moveY = 0;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();  //nos da la "clase" Animator.
        _animator.SetBool(MOVE_HANDS, isMovingHands);  //forzamos a poner el valor del script sin importar lo que haya
                                                       //marcado en el editor

        _animator.SetBool(IS_MOVING, isMoving);

        _animator.SetFloat(MOVE_X, moveX);
        _animator.SetFloat(MOVE_Y, moveY);
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("mover mano");
            isMovingHands = !isMovingHands;
            _animator.SetBool(MOVE_HANDS, isMovingHands);
            //asignamos el nuevo valor
        }

        if (Mathf.Sqrt(moveX*moveX + moveY * moveY) > 0.01)
        {
            _animator.SetBool(IS_MOVING, true);

            _animator.SetFloat(MOVE_X, moveX);
            _animator.SetFloat(MOVE_Y, moveY);
        }
        else
        {
            _animator.SetBool(IS_MOVING, false);
        }
    }
}
