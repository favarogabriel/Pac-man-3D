using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private float playerSpeed;
    private Rigidbody playerRb;

    public bool movingLeft;
    public bool movingRight;
    public bool movingUp;
    public bool movingDown;

    public int points;

    [SerializeField] private GameObject playerIdle;
    [SerializeField] private GameObject playerEat;


    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 8.0f;

        playerRb = GetComponent<Rigidbody>();

        playerRb.velocity = new Vector3(playerSpeed, 0, 0);
        points = 0;

        InvokeRepeating("PlayerAnimation", 0.0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movingUp = true;
            movingRight = false;
            movingLeft = false;
            movingDown = false;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movingUp = false;
            movingRight = false;
            movingLeft = false;
            movingDown = true;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movingUp = false;
            movingRight = true;
            movingLeft = false;
            movingDown = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movingUp = false;
            movingRight = false;
            movingLeft = true;
            movingDown = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Move Point"))
        {
            if (movingRight == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                playerRb.velocity = new Vector3(playerSpeed, 0, 0);
            }
            if (movingLeft == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                playerRb.velocity = new Vector3(-playerSpeed, 0, 0);
            }
            if (movingUp == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                playerRb.velocity = new Vector3(0, 0, playerSpeed);
            }
            if (movingDown == true)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                playerRb.velocity = new Vector3(0, 0, -playerSpeed);
            }
      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Move Point"))
        {
            movingDown = false;
            movingUp = false;
            movingRight = false;
            movingLeft = false;
        }
    }

    private void PlayerAnimation()
    {
        if (playerIdle.active == true)
        {
            playerEat.SetActive(true);
            playerIdle.SetActive(false);
        } else if (playerEat.active == true)
        {
            playerEat.SetActive(false);
            playerIdle.SetActive(true);
        }
    }
}
