using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [Header("Interval")]
    public float IntervalMin = 1.0f;
    public float IntervalMax = 4.0f;
    [Header("Obstacles")]
    public List<Obstacle> Obstacles;

    float _intervalMin;
    float _intervalMax;
    float _coolTime;
    float _accumulateTime;
    int _limit = 6;

    // Start is called before the first frame update
    void Awake()
    {
        _intervalMin = IntervalMin;
        _intervalMax = IntervalMax;
        _coolTime = Random.Range(_intervalMin, _intervalMax);
    }

    // Update is called once per frame
    void Update()
    {
        _accumulateTime += Time.deltaTime;

        if(_accumulateTime > _coolTime) {
            int index;
            do {
                index = Random.Range(0, _limit);
            } while(Obstacles[index].isSpawned);

            Obstacles[index].Spawn();

            _accumulateTime = 0;
            _coolTime = Random.Range(_intervalMin, _intervalMax);
        }
    }

    public void Init() {
        for(int i = 0; i < Obstacles.Count; i++) {
            Obstacles[i].Init();
        }
        _limit = 6;
        _intervalMin = 1.0f;
        _intervalMax = 4.0f;
    }

    public void Unlock() {
        _limit = 10;
    }

    public void SetInterval(float Ratio) {
        _intervalMin = IntervalMin * Ratio;
        _intervalMax = IntervalMax * Ratio;
    }
}
