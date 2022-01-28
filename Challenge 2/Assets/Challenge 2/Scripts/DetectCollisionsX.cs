using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("ground"))
        {
            Time.timeScale = 0;
            Debug.Log("GAME OVER");
        }
    


    }

}
