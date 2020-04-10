using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool Bird;

    public bool isSpawned {
        get {
            return _spawned;
        }
    }

    bool _spawned;

    // Update is called once per frame
    void Update()
    {
        if(!_spawned) {
            return;
        }
        float speed = GameManager.Instance.Dino.Speed + (Bird ? -2f : 0f);
        transform.position += (Vector3)(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < -22f) {
            transform.position = new Vector2(22f, transform.position.y);
            _spawned = false;
        }
    }

    public void Spawn() {
        _spawned = true;
    }

    public void Init() {
        transform.position = new Vector2(22f, transform.position.y);
        _spawned = false;
    }
}
