using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public List<Obstacle> Obstacles;
    public float DefaultIntervalStart = 1.0f;
    public float DefaultIntervalEnd = 4.0f;

    float IntervalStart = 1.0f;
    float IntervalEnd = 4.0f;
    float CoolTime;
    float AccTime;
    int Limit = 6;

    // Start is called before the first frame update
    void Start()
    {
        CoolTime = Random.Range(IntervalStart, IntervalEnd);
    }

    // Update is called once per frame
    void Update()
    {
        AccTime += Time.deltaTime;

        if(AccTime > CoolTime) {
            int index;
            do {
                index = Random.Range(0, Limit);
            } while(Obstacles[index].isSpawned());

            Obstacles[index].Spawn();

            AccTime = 0;
            CoolTime = Random.Range(IntervalStart, IntervalEnd);
        }
    }

    public void Init() {
        for(int i = 0; i < Obstacles.Count; i++) {
            Obstacles[i].Init();
        }
        Limit = 6;
        IntervalStart = 1.0f;
        IntervalEnd = 4.0f;
    }

    public void Unlock() {
        Limit = 10;
    }

    public void SetInterval(float Ratio) {
        IntervalStart = DefaultIntervalStart * Ratio;
        IntervalEnd = DefaultIntervalEnd * Ratio;
    }
}
