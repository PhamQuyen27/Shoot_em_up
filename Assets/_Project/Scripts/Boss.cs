using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //public khi muon cac game object thay doi gia tri
    //private khi muon cac game object khong thay doi gia tri
    //muon cho cac lap trinh vien thay doi gia tri thi them [SerializeField] truoc bien private
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleLaserPrefab;
    [SerializeField]
    private float _fireRate = 5f;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private float _tripleShotCoolDown = 5.0f;
    [SerializeField]
    private float _speedUpCoolDown = 5.0f;
    [SerializeField]
    private int _speedUpMultiplyTo = 2;
    [SerializeField]
    private int _scorce;



    private bool _canTripleShot = false;
    private bool _isShieldActive = false;



    //private float _timer = 0f;
    private float _canFire = -1f;
    private SpawnManager _spawnManager;

    Transform _shieldsTransform;
    Transform _rightEngineTransform;
    Transform _leftEngineTransform;

    private AudioManager _audioManager;


    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0,0,0)
        transform.position = new Vector3(0, transform.position.y, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL");
        }

        if (_audioManager == null)
        {
            Debug.LogError("Audio Manager is null");
        }

        _shieldsTransform = transform.Find("Shields");
        _shieldsTransform.gameObject.SetActive(false);
        _rightEngineTransform = transform.Find("Right_Engine");
        _rightEngineTransform.gameObject.SetActive(false);
        _leftEngineTransform = transform.Find("Left_Engine");
        _leftEngineTransform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
        //Instantiate(_enemy, new Vector3(Random.Range(-11.5f,14), 8.4f, 0), Quaternion.identity);
    }

    public int GetScore()
    {
        return _scorce;
    }

    public int GetLives()
    {
        return _lives;
    }

    public void IncreaseScore(int point)
    {
        _scorce += point;
    }

    public void ResetScorce()
    {
        _scorce = 0;
    }




    public void SpeedBoostActive()
    {
        _speed *= _speedUpMultiplyTo;
        StartCoroutine(SpeedDownRoutine());
    }

    IEnumerator SpeedDownRoutine()
    {
        yield return new WaitForSeconds(_speedUpCoolDown);
        _speed /= _speedUpMultiplyTo;
    }

    void FireLaser()
    {

        _canFire = Time.time + _fireRate;

        if (_canTripleShot == true)
        {
            Instantiate(_tripleLaserPrefab, transform.position + new Vector3(-0.6f, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }

        _audioManager.PlayLaserSound();
    }



    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");// -1 left, 1 right, 0 no input
        float verticalInput = Input.GetAxis("Vertical");// -1 down, 1 up, 0 no input

        Vector3 direction = new Vector3(horizontalInput, verticalInput);
        transform.Translate(_speed * Time.deltaTime * direction);

        //another way to do it
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.2f, 0), 0);


        if (transform.position.x >= 11.5f)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(11.5f, transform.position.y, 0);
        }
    }

}

