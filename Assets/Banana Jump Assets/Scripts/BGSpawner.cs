using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] bg;
    private float height;
    private float highestYPos;

    void Awake()
    {
        bg = GameObject.FindGameObjectsWithTag("BG");
        height = bg[0].GetComponent<BoxCollider2D>().bounds.size.y;
        highestYPos = bg[0].transform.position.y;

        for (int i = 1; i < bg.Length; i++)
        {
            if (bg[i].transform.position.y > highestYPos)
            {
                highestYPos = bg[i].transform.position.y;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BG")
        {
            if (other.transform.position.y >= highestYPos)
            {
                Vector3 temp = other.transform.position;
                for (int i = 0; i < bg.Length; i++)
                {
                    if (!bg[i].activeInHierarchy)
                    {
                        temp.y += height;
                        highestYPos = temp.y;
                        bg[i].transform.position = temp;
                        bg[i].SetActive(true);
                    }
                }
            }
        }
    }
}
