using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public List<Obstacle> Obstacles;
    public float CoolRangeStart = 1.0f;
    public float CoolRangeEnd = 4.0f;

    float CoolTime;
    float AccTime;

    // Start is called before the first frame update
    void Start()
    {
        CoolTime = Random.Range(CoolRangeStart, CoolRangeEnd);
    }

    // Update is called once per frame
    void Update()
    {
        AccTime += Time.deltaTime;

        if(AccTime > CoolTime) {
            int index;
            do {
                index = Random.Range(0, Obstacles.Count);
            } while(Obstacles[index].isSpawned());

            Obstacles[index].Spawn();

            AccTime = 0;
            CoolTime = Random.Range(CoolRangeStart, CoolRangeEnd);
        }
    }

    public void Init() {
        for(int i = 0; i < Obstacles.Count; i++) {
            Obstacles[i].Init();
        }
    }
}
