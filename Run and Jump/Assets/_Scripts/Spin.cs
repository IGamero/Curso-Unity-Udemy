using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float translateSpeed = 1f;
    public float rotateSpeed = 100;
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left*Time.deltaTime * translateSpeed);
        transform.localPosition += Vector3.left * translateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
