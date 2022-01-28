using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{

    //todo lo que empieza por "on" es un evento.

    /* OnTriggerEnter se llamara automaticamente cuando un objeto
     * entre dentro del trigger del gameObject que lleva este script
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            //este script (animal) choca contra un proyectil (especificado con el tag)
            Destroy(this.gameObject); //destruye el que lleva el script
            Destroy(other.gameObject); //destruye el que choca con el script
           
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
        }

        
     
    }
}
