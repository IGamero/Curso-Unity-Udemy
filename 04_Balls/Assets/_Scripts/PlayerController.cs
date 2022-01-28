using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigitBody;
   
    public float moveForce;

    //public GameObject focalPoint; //es mas correcto lo siguiente
    private GameObject focalPoint; //mirar en Start()

    public bool hasPowerUp;
    public float powerUpForce;
    public float powerUpTimer = 7;

    public GameObject[] powerUpIndicators;


    // Start is called before the first frame update
    void Start()
    {
        _rigitBody = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");  //nombre dado en el editor
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigitBody.AddForce(focalPoint.transform.forward * moveForce * forwardInput, ForceMode.Force);

        foreach (GameObject indicator in powerUpIndicators)
        {
            //  indicator.transform.position = new Vector3(this.transform.position.x, -0.5f, this.transform.position.z);  el anillo simpere esta a ras de suelo
            indicator.transform.position = this.transform.position + 0.5f * Vector3.down; // el anillo siempre esta debajo de la pelota
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;

            other.GetComponent<AutoDestroy>().destroy = true;
            StartCoroutine(PowerUpCountdown());

        }

        //destruye al jugador y termina el juego/gameOver.
        if (other.CompareTag("KillZone"))
        { 
            // Destroy(this.gameObject);
            SceneManager.LoadScene("Prototype 4");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigitBody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 repulseDirection = collision.gameObject.transform.position -  this.transform.position;
            enemyRigitBody.AddForce(repulseDirection * powerUpForce, ForceMode.Impulse);


            //Debug.Log("el jugador a colisionado con " + collision.gameObject + " y tiene el power up con valor " + hasPowerUp);
        }
    }

   
    IEnumerator PowerUpCountdown ()
    {

        for (int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].SetActive(true);
            yield return new WaitForSeconds(powerUpTimer / powerUpIndicators.Length);
            powerUpIndicators[i].SetActive(false);
            foreach (GameObject indicator in powerUpIndicators)
            {
                indicator.GetComponent<RotatePowerUp>().rotationSpeed -= 0.5f;
            }

        }

        //reseteamos valores de los anillos
        for (int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].GetComponent<RotatePowerUp>().rotationSpeed = -0.5f;
        }

        hasPowerUp = false;
    }
}
