using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Rigidbody2D shipBody;

    public bool isStart;
    private float shipFallSpeed;

    private void Update()
    {
        if (isStart)
        {
            shipFallSpeed = Mathf.MoveTowards(3.5f, 6f, 0.1f * Time.deltaTime);
        }
        shipBody.velocity = new Vector2(0,-shipFallSpeed);
    }
    public void PlayButton()
    {
        menuPanel.SetActive(false);
        shipBody.gravityScale = 1;
        isStart = true;
    }
}
