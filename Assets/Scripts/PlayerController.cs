using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private GameObject playerCloseMouth;
    [SerializeField] private GameObject playerOpenMouth;
    [SerializeField] float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        InvokeRepeating("PlayerAliveAnimation", 0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        int rotateDirection = 90;

        transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, rotateDirection, 0));
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -rotateDirection, 0));
        }
    }

    private void PlayerAliveAnimation()
    {
        if (playerOpenMouth.activeSelf == false)
        {
            playerOpenMouth.SetActive(true);
            playerCloseMouth.SetActive(false);
        } else
        {
            playerOpenMouth.SetActive(false);
            playerCloseMouth.SetActive(true);
        }
    }
}
