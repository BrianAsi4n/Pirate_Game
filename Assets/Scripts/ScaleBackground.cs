using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
     private SpriteRenderer bgSpr;
     private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        bgSpr = GetComponent<SpriteRenderer>();
        cam = Camera.main;

        //get the size of the camera
        float cameraHeight = 2f * cam.orthographicSize;
        float cameraWight = cameraHeight * cam.aspect;

        // get the size of the BG 
        float bgHeight = bgSpr.sprite.bounds.size.y;
        float bgWight = bgSpr.sprite.bounds.size.x;

        // scale ratio
        float scaleX = cameraWight / bgWight;
        float scaleY = cameraHeight / bgHeight;

        //apply scale to background
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
}
