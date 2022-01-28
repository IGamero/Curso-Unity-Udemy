using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;

    public bool onGround;

    

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < 2 && this.gameObject.transform.position.y > -0.5f)
        {
            Vector3 lookDirection = (player.transform.position - this.transform.position).normalized; //normalizamos el vector (10:30 clase 85)
            _rigidbody.AddForce(moveForce * lookDirection, ForceMode.Force);
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone")){
            Destroy(this.gameObject);
        }

    }
}
