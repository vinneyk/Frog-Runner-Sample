using UnityEngine;

public class PlatformPositionInfo
{
    private readonly Transform platformSource;

    [System.Obsolete]
    public float positionY;
    public bool hasMonster;
    public bool hasHealthCollectable;
    public Vector3 Position { get; set; }
    public Transform Instance { get; private set; }
    public Transform Monster { get; private set; }
    public Transform HealthCollectable { get; private set; }
    
    public PlatformPositionInfo(Transform originalPlatform, Vector3 position, bool hasMonster, bool hasHealthCollectable)
    {
        platformSource = originalPlatform;
        Position = position;
        this.hasMonster = hasMonster;
        this.hasHealthCollectable = hasHealthCollectable;
    }

    public Transform Instantiate(Transform parent, Quaternion? rotation = null)
    {
        Instance = Object.Instantiate(platformSource, Position, rotation ?? Quaternion.identity, parent);
        return Instance;
    }

    public Transform AddMonster(Transform originalMonster, Transform monsterParent)
    {
        var pos = Position;
        pos.y += 0.1f;
        Monster = Object.Instantiate(originalMonster, pos, Quaternion.Euler(0, -90, 0), monsterParent);
        return Monster;
    }

    public Transform AddHealthCollectable(Transform originalHealth, Transform healthParent, float yPosition)
    {
        var pos = Position;
        pos.y = yPosition;
        HealthCollectable = Object.Instantiate(originalHealth, pos, Quaternion.identity, healthParent);
        return HealthCollectable;
    }

    public void SetPositionX(float xPos)
    {
        var position = Position;
        position.x = xPos;
        Position = position;

        var instancePos = Instance.position;
        instancePos.x = xPos;
        Instance.position = instancePos;

        if (Monster != null) {
            var monsterPos = Monster.position;
            monsterPos.x = xPos;
            Monster.position = monsterPos;
        }

        if (HealthCollectable != null) {
            var healthPos = HealthCollectable.position;
            healthPos.x = xPos;
            HealthCollectable.position = healthPos;
        }
    }
}