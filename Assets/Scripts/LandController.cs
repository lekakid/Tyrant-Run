using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandController : MonoBehaviour
{
    public GameManager Manager;
    public List<GameObject> Lands;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Lands.Count; i++) {
            if(Lands[i].transform.position.x < -31.25f) {
                int j = (i + 2) % 3;
                
                Lands[i].transform.position = new Vector2(Lands[j].transform.position.x + 25f, Lands[i].transform.position.y);
            }

            Lands[i].transform.position += (Vector3)(Vector2.left * Manager.DinoSpeed * Time.deltaTime);
        }
    }
}
