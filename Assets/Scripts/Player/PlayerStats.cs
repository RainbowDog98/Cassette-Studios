﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private float playerRangedDamage;

    [SerializeField]
    private float playerRangedSpeed;
    
    [SerializeField]
    private int defence;

    [SerializeField]
    private int numberOfJumps;

    [SerializeField]
    private float playerDamage;

    [SerializeField]
    private float movementSpeed;
    
    [SerializeField]
    private int currentHealth;

    public PlayerHealthBar playerHealthBar;


    public int GetPlayerMaxHealth() => maxHealth;
    public int GetPlayerDefence() => defence;
    public int GetPlayerNumberOfJumps() => numberOfJumps;
    public float GetPlayerDamage() => playerDamage;
    public float GetPlayerMovementSpeed () => movementSpeed;
    public float GetPlayerRangedDamage() => playerRangedDamage;
    public float GetPlayerRangedSpeed() => playerRangedSpeed;

    public void SetPlayerMaxHealth(int value)
    {
        maxHealth = value;
    }
    public void SetPlayerDefence(int value)
    {
        defence = value;
    }
    public void SetPlayerNumberOfJumps(int value)
    {
        numberOfJumps = value;
    }
    public void SetPlayerDamage(float value)
    {
        playerDamage = value;
    }
    public void SetPlayerMovementSpeed(float value)
    {
        movementSpeed = value;
    }
    public void SetPlayerRangedDamage(float value)
    {
        playerRangedDamage = value;
    }
    public void SetPlayerRangedSpeed(float value)
    {
        playerRangedSpeed = value;
    }
    private void Start()
    {
        PlayerData data = SaveSystem.LoadSave();
        if(data != null) // If save file exists
        {
            maxHealth = data.maxHealth;
            currentHealth = data.currentHealth;
            playerDamage = data.playerDamage;
            playerRangedDamage = data.playerRangedDamage;
            playerRangedSpeed = data.playerRangedSpeed;
            defence = data.defence;
            numberOfJumps = data.numberOfJumps;
            movementSpeed = data.movementSpeed;
            Debug.Log("File succsessfully loaded");
        }
        else // if save file is not found, assing defaul values
        {
            SetDefaultStats();
        }

        playerHealthBar.SetMaxHealth(maxHealth);
        playerHealthBar.SetHealth(currentHealth);
    }

    private void SetDefaultStats()
    {
        maxHealth = 100;
        playerDamage = 10;
        playerRangedDamage = 10;
        playerRangedSpeed = 10;
        defence = 0;
        numberOfJumps = 1;
        movementSpeed = 10;
        currentHealth = maxHealth;
    }

    private void OnDestroy()
    {
        SaveSystem.SavePlayer(maxHealth, currentHealth, defence, numberOfJumps, playerRangedDamage, playerRangedSpeed, playerDamage, movementSpeed);
    }
    public void DecreaseHealth(int damage)
    {
        // Damage reduction
        var newDamage = damage - Math.Abs(defence * 0.75f);
        
        currentHealth -= (int)newDamage;
        Debug.Log(currentHealth);
        playerHealthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SetDefaultStats(); // restores original values before player save is started
        Destroy(gameObject);
    }
}
