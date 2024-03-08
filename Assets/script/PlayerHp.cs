using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float playerHp;
    public RectTransform valueRectTransform;

    private float _maxValue;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    
    private void Start()
    {
        _maxValue = playerHp;
        DrawHealthBar();
    }
    
    public void DealDamag(float damage)
    {
        playerHp -= damage;
        if (playerHp <= 0)
        {
            GameUI();
        }
        DrawHealthBar();
    }

    void GameUI()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

    void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(playerHp/_maxValue,1);
    }
}
