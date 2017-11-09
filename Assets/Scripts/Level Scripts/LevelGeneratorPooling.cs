using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGeneratorPooling : MonoBehaviour
{
    [SerializeField]
    private int startPlatformLength = 5;

    [SerializeField]
    private Transform platform, platformParent;

    [SerializeField]
    private Transform monster, monsterParent;

    [SerializeField]
    private Transform healthCollectable, healthCollectableParent;

    [SerializeField]
    private int levelLength = 100;

    [SerializeField]
    private float distanceBetweenPlatforms = 6;

    [SerializeField]
    private float minPositionY, maxPositionY;

    [SerializeField]
    private float chanceForMonsterExistance, chanceForHealthCollectableExistance;

    [SerializeField]
    private float healthCollectableMinY, healthCollectableMaxY;

    private float platformLastPositionX = 0;
    private PlatformPositionInfo[] platforms;

	void Start () {
        platforms = new PlatformPositionInfo[levelLength];
                
        for (var i = 0; i < platforms.Length; i++)
        {
            var currentPlatform = GeneratePlatform(i);

            platforms[i] = currentPlatform;
        }

        platformLastPositionX = platforms.Last().Position.x;
    }
	
    public void ExtendPlatforms()
    {
        var inactivePlatforms = platforms.Where(p => !p.Instance.gameObject.activeInHierarchy).ToList();
        inactivePlatforms.ForEach(p =>
        {
            p.SetPositionX(platformLastPositionX + distanceBetweenPlatforms);
            p.Instance.gameObject.SetActive(true);
            platformLastPositionX = p.Position.x;
        });
    }

    private PlatformPositionInfo GeneratePlatform(int index)
    {
        var isStartingPlatform = index < startPlatformLength;
        var pos = Vector3.zero;
        pos.x = distanceBetweenPlatforms * index;
        pos.y = isStartingPlatform ? 0 : Random.Range(minPositionY, maxPositionY);
        
       var currentPlatform = new PlatformPositionInfo(platform, pos,
                isStartingPlatform ? false : Random.Range(0f, 1f) < chanceForMonsterExistance,
                isStartingPlatform ? false : Random.Range(0f, 1f) < chanceForHealthCollectableExistance);
        currentPlatform.Instantiate(platformParent);

        if (currentPlatform.hasMonster)
        {
            currentPlatform.AddMonster(monster, monsterParent);
        }

        if (currentPlatform.hasHealthCollectable)
        {
            currentPlatform.AddHealthCollectable(healthCollectable, healthCollectableParent, pos.y + Random.Range(healthCollectableMinY, healthCollectableMaxY));
        }

        return currentPlatform;
    }
}
