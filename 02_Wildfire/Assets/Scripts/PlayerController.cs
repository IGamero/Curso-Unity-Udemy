using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 15.0f;

    public GameObject projectilPrefab;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento personaje
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontalInput);

        if (transform.position.x < -xRange)
        { 
            //muro izq
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
             
        }

        if (transform.position.x > xRange)
        {
            //muro izq
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }

        //acciones personaje
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Si entramos aqui, hay que lanzar un proyectil
            //Instanciamos(creamos) un proyectil

            Instantiate(projectilPrefab, transform.position, projectilPrefab.transform.rotation);

        }



    }
}
