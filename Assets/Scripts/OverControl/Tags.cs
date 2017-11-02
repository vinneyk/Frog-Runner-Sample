using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public static string GAME_CONTROLLER = "Controller";

    public const string PLAYER_TAG = "Player";
    public const string PLATFORM_TAG = "Platform";
    public const string BOUNDS_TAG = "Bounds";
    public const string MORE_PLATFORMS_TAG = "MorePlatforms";
    public const string HEALTH_TAG = "Health";
    public const string MONSTER_TAG = "Monster";
    public const string MONSTER_BULLET_TAG = "MonsterTag";
    public const string PLAYER_BULLET_TAG = "PlayerBullet";

    public const string ANIMATION_IDLE = "idle";
    public const string ANIMATION_RUN = "run";
    public const string ANIMATION_WALK = "walk";
    public const string ANIMATION_JUMP = "jump";
    public const string ANIMATION_JUMP_FALL = "jumpFall";
    public const string ANIMATION_JUMP_LAND = "jumpLand";
    public const string ANIMATION_LEDGE_FALL = "ledgeFall";
}

public class GameObjects : MonoBehaviour
{
    public static string BACKGROUND = "Background";
    public static string LEVEL_GENERATOR = "Level Generator";
}