using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        if(this.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
