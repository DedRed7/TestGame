using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    public float targetSpeed = 1f;
    public float cameraSpeed = 1f;
    public TileCoordinates tileCoordinates;
    public float maxLeadDistanceX = 1f;
    public float maxLeadDistanceY = 1f;
    public Transform player;

    private Vector3 target;
    private float previousX;
    private float previousY;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(tileCoordinates.x > previousX) target = Vector3.right * 20f + transform.position; //move right
        if(tileCoordinates.x < previousX) target = -Vector3.right * 20f + transform.position; //move left
        if(tileCoordinates.y > previousY) target = Vector3.forward * 20f + transform.position; //move up
        if(tileCoordinates.y < previousY) target = -Vector3.forward * 20f + transform.position; //move down

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * lerpSpeed);
        
        previousX = tileCoordinates.x;
        previousY = tileCoordinates.y;
        //*/
        
        if (player.position.x > previousX && target.x <= maxLeadDistanceX) target += targetSpeed * Time.deltaTime * Vector3.right;
        if (player.position.x < previousX && -target.x <= maxLeadDistanceX) target += targetSpeed * Time.deltaTime * Vector3.left;

        if (player.position.z > previousY && target.z <= maxLeadDistanceY) target += targetSpeed * Time.deltaTime * Vector3.forward;
        if (player.position.z < previousY && -target.z <= maxLeadDistanceY) target += targetSpeed * Time.deltaTime * Vector3.back;
        
        transform.position = Vector3.Lerp(transform.position, player.position + target, Time.deltaTime * cameraSpeed);
        
        previousX = player.position.x;
        previousY = player.position.z;
    }
}
