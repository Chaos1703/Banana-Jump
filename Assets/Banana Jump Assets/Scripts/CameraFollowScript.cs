using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform Target;
    private bool followPlayer;
    public float yThreshold = -2.6f;

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer(){
        if(Target.position.y < transform.position.y - yThreshold){
            followPlayer = false;
        }
        if(Target.position.y > transform.position.y){
            followPlayer = true;
        }
        if(followPlayer){
            Vector3 temp = transform.position;
            temp.y = Target.position.y;
            transform.position = temp;
        }
    }
}
