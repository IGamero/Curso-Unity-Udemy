using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 10)]
    public float moveSpeed = 10; //cinematita
    [Range(0, 360)]
    public float rotateSpeed = 180; //cinematita

    [Range(0, 10)]
    public float force = 10; //fisica

    public bool usePhysicsEngine; //para poder elegir en unity si usamos cinematica o fisica

    private Rigidbody _rigidbody;

    private float verticalInput, horizontalImput;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalImput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        MovePlayer();

        CheckBounds();

    }

    void MovePlayer()
    {

        if (usePhysicsEngine)
        {
            //Si se utiliza la fisica
            //AddForce sobre el rigitbody (desplazamientos)
            //AddTorque sobre rb (torsiones)

            _rigidbody.AddForce(Vector3.forward * Time.deltaTime * force * verticalInput, ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * Time.deltaTime * force * horizontalImput, ForceMode.Force);

        }
        else
        {
            //Si no se utiliza la fisica no se usa rigitbody
            //Nos movemos por medio de 
            //Translate() - transform -> moverse
            //Rotate() - transform -> rotar

            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * horizontalImput);

        }

    }

    void CheckBounds()
    {

        //TODO: Refactorizar la posicion limite en una variable

        if (Mathf.Abs(transform.position.x) >= 20 || Mathf.Abs(transform.position.z) >= 20)
        {
            _rigidbody.velocity = Vector3.zero;

            if (transform.position.x > 20)
            {
                transform.position = new Vector3(20, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -20)
            {
                transform.position = new Vector3(-20, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 20)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 20);
            }

            if (transform.position.z < -20)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -20);
            }

        }
    }
}
