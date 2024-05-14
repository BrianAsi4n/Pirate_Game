using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private Rigidbody2D shipBody;

    public bool isStart;
    private float shipFallSpeed;

    private int coin;
    [SerializeField] private TMP_Text coinText;

    private void Start()
    {
        if (Instance == null)
        Instance = this;
    }

    private void Update()
    {
        if (isStart)
        {
            shipFallSpeed = Mathf.MoveTowards(Constants.SHIP_MIN_SPEED, Constants.SHIP_MAX_SPEED, 0.1f * Time.deltaTime);
        }
        shipBody.velocity = new Vector2(0,-shipFallSpeed);
    }
    public void PlayButton()
    {
        menuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        shipBody.gravityScale = 1;
        isStart = true;
    }
    public void UpdateCoin() 
    {
        coin++;
        coinText.text = coin.ToString();
        Debug.Log(coin);
    }
}
