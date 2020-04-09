using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager Manager;

    bool spawned;

    // Update is called once per frame
    void Update()
    {
        if(!spawned) {
            return;
        }
        transform.position += (Vector3)(Vector2.left * Manager.DinoSpeed * Time.deltaTime);

        if(transform.position.x < -22f) {
            transform.position = new Vector2(22f, transform.position.y);
            spawned = false;
        }
    }

    public void Spawn() {
        spawned = true;
    }

    public bool isSpawned() {
        return spawned;
    }

    public void Init() {
        transform.position = new Vector2(22f, transform.position.y);
    }
}
