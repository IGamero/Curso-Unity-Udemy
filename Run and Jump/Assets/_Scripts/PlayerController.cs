using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{

    private const string SPEED_MULTIPLIER = "Speed_Multiplier";
    private  const string JUMP_TRIG = "Jump_trig";
    private const string SPEED_F = "Speed_f";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE_INT = "DeathType_int";

    private Rigidbody playerRb;

    public float jumpForce;
    public float gravityMultiplier;
    public bool isOnGround = true;

    public float speedLimit = 50;

    private bool _gameOver = false;
    public bool GameOver
    {

        // => es una funcion landa y puede usarse en lugar de {}

        get => _gameOver; //metodo getter
        //set => _gameOver = value; //metodo setter

        //otra forma para evitar que se cambie de forma externa
        //(pero no vale pa na, simplemente no se impleneta el set y ale)
                
        set
        {
            if (_gameOver == true)
            {
                _gameOver = true;
            }
            _gameOver = value;
        }    
    }

    private Animator _animator;
    private float speedMultiplier = 1;

    public ParticleSystem explosion, runEffect;

    public bool isRunEffectOn = false;

    public AudioClip []jumpSound;
    public AudioClip []crashSound;
    [Range(0, 1)] public float audioVolume = 1;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()

    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);
        _animator = GetComponent<Animator>();
        _animator.SetFloat(SPEED_F, 1.5f);

        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime/speedLimit;
      
        _animator.SetFloat(SPEED_MULTIPLIER, speedMultiplier);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            isRunEffectOn = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //F = m*a
            isOnGround = false;
            _animator.SetTrigger(JUMP_TRIG);

            _audioSource.PlayOneShot(jumpSound[Random.Range(0, 3)], audioVolume);
        }

        if(isOnGround && !GameOver)
        {
            isRunEffectOn = true;
        }
        else if (GameOver)
        {
            isRunEffectOn = false;

        }
        
        if (isRunEffectOn)
        {
            runEffect.gameObject.SetActive(true);

        }
        else{
            runEffect.gameObject.SetActive(false);
        }

      
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }else if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("GAME OVER");            

            explosion.Play();

            _animator.SetBool(DEATH_B , true);
            _animator.SetInteger(DEATH_TYPE_INT, Random.Range(1, 3)); 

            _audioSource.PlayOneShot(crashSound[Random.Range(0, 3)], audioVolume);

            Invoke("RestartGame", 2.0f);
        }
       
    }

    void RestartGame()
    {
        speedMultiplier = 1;
        SceneManager.LoadSceneAsync("Prototype 3", LoadSceneMode.Single);
    }
}
