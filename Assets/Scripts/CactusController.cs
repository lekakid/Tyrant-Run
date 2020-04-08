using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : MonoBehaviour
{
    public List<Cactus> Cactuses;

    float CoolTime;
    float AccTime;

    // Start is called before the first frame update
    void Start()
    {
        CoolTime = Random.Range(1.5f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        AccTime += Time.deltaTime;

        if(AccTime > CoolTime) {
            int index;
            do {
                index = Random.Range(0, Cactuses.Count);
            } while(Cactuses[index].isSpawned());

            Cactuses[index].Spawn();

            AccTime = 0;
            CoolTime = Random.Range(1.5f, 4f);
        }
    }

    public void Init() {
        for(int i = 0; i < Cactuses.Count; i++) {
            Cactuses[i].Init();
        }
    }
}
