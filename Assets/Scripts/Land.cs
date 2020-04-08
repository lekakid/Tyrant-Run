using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public GameManager Manager;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(Vector2.left * Manager.DinoSpeed * Time.deltaTime);

        if(transform.position.x < -31.25) {
            transform.position = new Vector2(43.75f, transform.position.y);
        }
    }
}
