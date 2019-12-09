using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_follow : MonoBehaviour
{

    public Transform PlayerTransform;

    private Vector3 offset;

    float distance;
    Vector3 playerPrevPos, playerMoveDir;

    void Start()
    {
        offset = transform.position - PlayerTransform.position;

        distance = offset.magnitude;
        playerPrevPos = PlayerTransform.position;

    }

    void LateUpdate()
    {
        playerMoveDir = PlayerTransform.position - playerPrevPos;
        if (playerMoveDir != Vector3.zero)
        {
            playerMoveDir.Normalize();
            Vector3 myv = PlayerTransform.position - playerMoveDir * distance;
            transform.position = new Vector3(myv.x, 5f, myv.z);


            transform.LookAt(new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + 1f, PlayerTransform.position.z));

            playerPrevPos = PlayerTransform.position;
        }
    }
}
