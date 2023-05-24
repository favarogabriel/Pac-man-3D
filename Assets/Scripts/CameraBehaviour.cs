using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        offSet = new Vector3(0, 12.0f, -12.50f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position + offSet;
    }
}
