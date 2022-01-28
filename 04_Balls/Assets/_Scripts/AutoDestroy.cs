using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float x, y, z;
    public float resiceSpeed = 1;
    public bool destroy;

    private RotatePowerUp _rotatePowerUp;
    

    private void Start()
    {
  
        _rotatePowerUp = GetComponent<RotatePowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
  
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
        if (destroy)
        {
            _rotatePowerUp.rotationSpeed = 10;

            x -= resiceSpeed * Time.deltaTime;
            y -= resiceSpeed * Time.deltaTime;
            z -= resiceSpeed * Time.deltaTime;

            this.transform.localScale = new Vector3(x, y, z);
            
            if (x <= 0 || y <= 0 || z <= 0)
            {
                //destroy = false;
                
                Destroy(gameObject);
            }
        }

       
    }
}
