using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    private Rigidbody ghostRb;

    private float ghostSpeed;
    public bool isActive;

    public bool movingLeft;
    public bool movingRight;
    public bool movingUp;
    public bool movingDown;

    // Start is called before the first frame update
    void Start()
    {
        ghostSpeed = 8.0f;
        ghostRb = GetComponent<Rigidbody>();

        StartGhosts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGhosts()
    {
        if (gameObject.CompareTag("Red Ghost"))
        {
            StartCoroutine("RedGhostStart");
        } else if (gameObject.CompareTag("Pink Ghost"))
        {
            StartCoroutine("PinkGhostStart");
        }
        else if (gameObject.CompareTag("Blue Ghost"))
        {
            StartCoroutine("BlueGhostStart");
        }
    }

    private IEnumerator RedGhostStart()
    {
        yield return new WaitForSeconds(1);
        ghostRb.velocity = new Vector3(0, 0, ghostSpeed);
    }

    private IEnumerator PinkGhostStart()
    {
        yield return new WaitForSeconds(5);
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        ghostRb.velocity = new Vector3(ghostSpeed, 0, 0);
    }

    private IEnumerator BlueGhostStart()
    {
        yield return new WaitForSeconds(10);
        gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        ghostRb.velocity = new Vector3(-ghostSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Move Point Ghost"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            ghostRb.velocity = new Vector3(ghostSpeed, 0, 0);
            isActive = true;
        }

        if (other.gameObject.CompareTag("Move Point Home"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            ghostRb.velocity = new Vector3(0, 0, ghostSpeed);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            movingDown = true;
        }

        if (other.gameObject.CompareTag("Move Point"))
        {
            RotatingPoint rotatingPointScript = other.GetComponent<RotatingPoint>();

            if (movingRight == true && isActive == true && rotatingPointScript.noRight == false)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                ghostRb.velocity = new Vector3(ghostSpeed, 0, 0);
            }
            if (movingLeft == true && isActive == true && rotatingPointScript.noLeft == false)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                ghostRb.velocity = new Vector3(-ghostSpeed, 0, 0);          
            }
            if (movingUp == true && isActive == true && rotatingPointScript.noUp == false)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                ghostRb.velocity = new Vector3(0, 0, ghostSpeed);
            }
            if (movingDown == true && isActive == true && rotatingPointScript.noDown == false)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                ghostRb.velocity = new Vector3(0, 0, -ghostSpeed);
            }

        }
    }
}
