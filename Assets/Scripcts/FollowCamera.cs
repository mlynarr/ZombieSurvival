using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, -6);

    private float currentYaw = 0f;
    public float turnSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentYaw += Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = player.position - Quaternion.Euler(0, currentYaw, 0) * offset;
        transform.LookAt(player.position + Vector3.up * 2);
    }
}
