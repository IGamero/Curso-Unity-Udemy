using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{

    private float topBound = 30f;
    private float botBound = -15f;

     // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.z < botBound)
        {
            Debug.Log("GAME OVER, inutil :D");
            Destroy(this.gameObject);
            Time.timeScale = 0;
              
        }
    }   
}
