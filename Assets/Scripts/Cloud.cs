using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(Vector2.left * 2f * Time.deltaTime);

        if(transform.position.x < -21f) {
            transform.position = new Vector2(Random.Range(21f, 24f), Random.Range(0f, 3f));
        }
    }
}
