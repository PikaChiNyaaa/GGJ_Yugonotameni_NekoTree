using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    /*Parallax:
     * Cool Parallax Background Effect
     * 
     * Referenced video tutorial: https://www.youtube.com/watch?v=zit45k6CUMk
     * Tutorial by: Dani
     */

    [SerializeField] float parallaxEffect;

    private float length, startPos;
    public GameObject cam;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
