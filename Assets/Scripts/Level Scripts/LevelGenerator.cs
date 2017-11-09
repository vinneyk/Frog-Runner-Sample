using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private int levelLength;

    [SerializeField]
    private int startPlatformLength = 5, endPlatformLength = 5;

    [SerializeField]
    private int distanceBetweenPlatforms;

    [SerializeField]
    private int distanceBetweenPlatformsMin;

    [SerializeField]
    private int distanceBetweenPlatformsMax;

    [SerializeField]
    private Transform platformPrefab, platformParent;

    [SerializeField]
    private Transform monster, monsterParent;

    [SerializeField]
    private Transform healthCollectable, healthCollectableParent;

    [SerializeField]
    private float platformPosition_minY = 0f, platformPosition_maxY = 10f;

    [SerializeField]
    private int platformLength_min = 1, platformLength_max = 4;

    [SerializeField]
    private float chanceForMonsterExistance = 0.25f, chanceForCollectableExistance = 0.1f;

    [SerializeField]
    private float healthCollectable_minY = 1f, healthCollectable_maxY = 3f;

    private float platformLastPositionX;

    private enum PlatformType
    {
        None, 
        Flat
    }

    void FillOutPositionInfo(PlatformPositionInfo[] platformInfo)
    {
        int currentPlatformInfoIndex = 0;

        for(int i = 0; i < startPlatformLength; i++)
        {
            //platformInfo[i].platformType = PlatformType.Flat;
            platformInfo[i].positionY = 0f;

            currentPlatformInfoIndex++;
        }

        while (currentPlatformInfoIndex < levelLength - endPlatformLength)
        {
            //if (platformInfo[currentPlatformInfoIndex - 1].platformType != PlatformType.None)
            //{
            //    currentPlatformInfoIndex++;
            //    continue;
            //}

            float platformPositionY = Random.Range(platformPosition_minY, platformPosition_maxY);
            int platformLength = Random.Range(platformLength_min, platformLength_max);

            for(int i = 0; i < platformLength; i++)
            {
                bool hasMonster = (Random.Range(0f, 1f) < chanceForMonsterExistance);
                bool hasHealthCollectable = (Random.Range(0f, 1f) < chanceForCollectableExistance);

                //platformInfo[currentPlatformInfoIndex].platformType = PlatformType.Flat;
                platformInfo[currentPlatformInfoIndex].positionY = platformPositionY;
                platformInfo[currentPlatformInfoIndex].hasMonster = hasMonster;
                platformInfo[currentPlatformInfoIndex].hasHealthCollectable = hasHealthCollectable;

                currentPlatformInfoIndex++;

                if(currentPlatformInfoIndex > (levelLength - endPlatformLength))
                {
                    currentPlatformInfoIndex = levelLength - endPlatformLength;
                    break;
                }
            }
        }

        for(int i = 0; i < endPlatformLength; i++)
        {
            //platformInfo[currentPlatformInfoIndex].platformType = PlatformType.Flat;
            platformInfo[currentPlatformInfoIndex].positionY = 0f;

            currentPlatformInfoIndex++;
        }
    }

    void CreatePlatformsFromPositionInfo(PlatformPositionInfo[] platformPositionInfo, bool firstRun)
    {
        PlatformPositionInfo current;
        for (int i = 0; i < platformPositionInfo.Length; i++)
        {
            current = platformPositionInfo[i];
            ////if(current.platformType == PlatformType.None)
            //{
            //    continue;
            //}

            //todo: check if game is started or not

            Vector3 platformPosition;
            
            platformPosition = firstRun 
                ? new Vector3(distanceBetweenPlatforms * i, current.positionY, 0)
                : new Vector3(distanceBetweenPlatforms + platformLastPositionX, current.positionY, 0);

            platformLastPositionX = platformPosition.x;
            
            Transform createBlock = Instantiate(platformPrefab, platformPosition, Quaternion.identity, platformParent);
            //createBlock.parent = platformParent;

            if(current.hasMonster)
            {
                if(firstRun)
                {
                    platformPosition = new Vector3(distanceBetweenPlatforms * i, current.positionY + 0.1f, 0);
                } else
                {
                    platformPosition = new Vector3(distanceBetweenPlatforms + platformLastPositionX, current.positionY + 0.1f, 0);
                }

                var createMonster = Instantiate(monster, platformPosition, Quaternion.Euler(0, -90, 0), monsterParent);
            }

            if(current.hasHealthCollectable)
            {
                if(firstRun)
                {
                    platformPosition = new Vector3(distanceBetweenPlatforms * i, current.positionY + Random.Range(healthCollectable_minY, healthCollectable_maxY), 0);
                } else
                {
                    platformPosition = new Vector3(distanceBetweenPlatforms + platformLastPositionX, current.positionY + Random.Range(healthCollectable_minY, healthCollectable_maxY), 0);
                }
                var createHealthCollectable = Instantiate(healthCollectable, platformPosition, Quaternion.identity);
                createHealthCollectable.parent = healthCollectableParent;
            }
        }
    }

    //public void GeneratePlatforms()
    //{
    //    GenerateLevel(false);
    //}
    //private void GenerateLevel(bool firstRun) {
    //    var platformInfo = new PlatformPositionInfo[levelLength];
    //    for (int i = 0; i < platformInfo.Length; i++) {
    //        platformInfo[i] = new PlatformPositionInfo(PlatformType.None, -1f, false, false);
    //    }

    //    FillOutPositionInfo(platformInfo);
    //    CreatePlatformsFromPositionInfo(platformInfo, firstRun);
    //}

    // Use this for initialization
 //   void Start () {
 //       GenerateLevel(true);
	//}
	
}
