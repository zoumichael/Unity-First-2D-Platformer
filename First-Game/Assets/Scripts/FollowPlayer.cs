using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float xBoundaryLeft;
    [SerializeField] private float xBoundaryRight;
    [SerializeField] private float yBoundaryDown;
    [SerializeField] private float yBoundaryDownUp;


    void Update()
    {
        float cameraX = player.position.x;
        float cameraY = player.position.y;

        if(player.position.x < xBoundaryLeft)
        {
            cameraX = xBoundaryLeft;
        }
        else if(player.position.x > xBoundaryRight)
        {
            cameraX = xBoundaryRight;
        }
        if(player.position.y < yBoundaryDown){

        }
        transform.position = new Vector3(cameraX, player.position.y, transform.position.z);
    }
}
