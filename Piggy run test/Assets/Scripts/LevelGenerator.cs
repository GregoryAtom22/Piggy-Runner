using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_SPAWN_LEVEL_PART = 30f;
    [SerializeField] private Transform LevelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;
    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = LevelPart_Start.Find("EndPosition").position;
        
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
