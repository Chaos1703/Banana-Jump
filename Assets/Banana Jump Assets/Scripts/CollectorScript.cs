using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "BG" || target.tag == "NormalPush" || target.tag == "ExtraPush" || target.tag == "Platform" || target.tag == "Bird")
        {
            target.gameObject.SetActive(false);
        }
    }
}
