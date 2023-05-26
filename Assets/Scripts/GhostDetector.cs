using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetector : MonoBehaviour
{
    private GhostBehaviour ghostBehaviourScript;

    // Start is called before the first frame update
    void Start()
    {
        ghostBehaviourScript = GameObject.Find("Red Ghost").GetComponent<GhostBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Top Detector") && ghostBehaviourScript.isActive == true)
            {
                ghostBehaviourScript.movingUp = true;
                ghostBehaviourScript.movingDown = false;
                ghostBehaviourScript.movingRight = false;
                ghostBehaviourScript.movingLeft = false;
            }

            if (gameObject.CompareTag("Bottom Detector") && ghostBehaviourScript.isActive == true)
            {
                ghostBehaviourScript.movingUp = false;
                ghostBehaviourScript.movingDown = true;
                ghostBehaviourScript.movingRight = false;
                ghostBehaviourScript.movingLeft = false;
            }

            if (gameObject.CompareTag("Right Detector") && ghostBehaviourScript.isActive == true)
            {
                ghostBehaviourScript.movingUp = false;
                ghostBehaviourScript.movingDown = false;
                ghostBehaviourScript.movingRight = true;
                ghostBehaviourScript.movingLeft = false;
            }

            if (gameObject.CompareTag("Left Detector") && ghostBehaviourScript.isActive == true)
            {
                ghostBehaviourScript.movingUp = true;
                ghostBehaviourScript.movingDown = false;
                ghostBehaviourScript.movingRight = false;
                ghostBehaviourScript.movingLeft = true;
            }
        }
    }
}
