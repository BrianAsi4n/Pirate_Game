using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastSpaw : MonoBehaviour
{
    public GameObject mastPrefab;
    public Transform container, player, lastMast;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(new Vector2(0, player.position.y),
            new Vector2(0, lastMast.transform.position.y)) < 6f)
        {
          GameObject spawnMast =  Instantiate(mastPrefab,
              new Vector2(0f, lastMast.GetChild(0).position.y),
              Quaternion.identity);
            spawnMast.transform.parent = container;
            lastMast = spawnMast.transform;

            int coinCount = Random.Range(0, lastMast.GetChild(2).childCount);
            if(coinCount > 0)
            {
                for(int i = 0; i < coinCount; i++)
                {
                    int WhiCoin = Random.Range(0, lastMast.GetChild(2).childCount);
                    GameObject lastPack = lastMast.GetChild(2).GetChild(WhiCoin).gameObject;
                    lastPack.SetActive(false);

                }
            }
        }
    }
}
