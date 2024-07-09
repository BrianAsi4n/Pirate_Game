using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip sideAudio, dieAudio, coinAudio;

    // [SerializeField] private GameManager gameManager;
    public Transform lastMast;
    private AudioSource audio;
     private SpriteRenderer spr;

    private float initialY;


    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        initialY = lastMast.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if(transform.position.x >= 0)
            {
                spr.flipX = false;
            }
            else
            {
                spr .flipX = true;
            }
            audio.PlayOneShot(sideAudio);
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == Constants.OBSTACLE_TAG)
        {
            GameManager.Instance.EndGame();
            audio.PlayOneShot(dieAudio);
        }
        else if (collision.gameObject.tag == Constants.COIN_TAG)
        {
            Debug.Log("coin");
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateCoin();
            audio.PlayOneShot(coinAudio);
        }
        else if (collision.gameObject.tag == Constants.LEIGHT_TAG)
        {
            float heightDifference = lastMast.position.y - initialY;
            Debug.Log("Height Difference: " + heightDifference);
            GameManager.Instance.UpdateLeight();
        }
        
    }
}
