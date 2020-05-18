﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemSpawningScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ushort count = 0;
        foreach (var item in LevelManager.currentLevelData.Value.spawnambles)
        {
            Transform instance = null;
            switch (item.Item3)
            {
                default:
                case SpawnType.BirdEnemy:
                    Debug.Log("Should spawn a bird");
                    //if (!item.IsDead)
                    //Instantiate((Resources.Load("Bird") as GameObject).GetComponent<Transform>(), item.transform + new Vector2(0,1.5f), Quaternion.identity);
                    break;
                case SpawnType.SkeletonEnemy:
                    Debug.Log("Skeleton Spawned");
                    if (!item.IsDead)
                        instance = Instantiate((Resources.Load("Skeleton") as GameObject).GetComponent<Transform>(), item.transform + new Vector2(0, 1), Quaternion.identity);
                    break;
                case SpawnType.StrangeEnemy:
                    Debug.Log("Strange enemy Spawned");
                    if (!item.IsDead)
                        instance = Instantiate((Resources.Load("Enemy1") as GameObject).GetComponent<Transform>(), item.transform + new Vector2(0, 1), Quaternion.identity);
                    break;
                case SpawnType.GoldCoin:
                    Debug.Log("Coin Spawned");
                    if (!item.IsDead)
                        instance = Instantiate((Resources.Load("GroundCoin") as GameObject).GetComponent<Transform>(), item.transform, Quaternion.identity);
                    break;
                case SpawnType.GoldChest:
                    Debug.Log("Chest Spawned");
                    if(!item.IsDead)
                        instance = Instantiate((Resources.Load("Chest") as GameObject).GetComponent<Transform>(), item.transform, Quaternion.identity);
                    break;

            }

            if (instance != null)
            {
                var enemy = instance.GetComponent<EnemyStats>();
                var coin = instance.GetComponent<Coin>();
                var chest = instance.GetComponent<Chest>();
               
                if (enemy != null)
                    enemy.SpawnedIndex = count;
                else if (coin != null)
                    coin.SpawnedIndex = count;
                else if (chest != null)
                    chest.SpawnedIndex = count;
            }

            count++;
        }
    }

}