﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
    public static string GAME_CONTROLLER = "Controller";

    public static string PLAYER_TAG = "Player";
    public static string PLATFORM_TAG = "Platform";
    public static string MORE_PLATFORMS_TAG = "MorePlatforms";
    public static string HEALTH_TAG = "Health";
    public static string MONSTER_TAG = "Monster";
    public static string MONSTER_BULLET_TAG = "MonsterTag";
    public static string PLAYER_BULLET_TAG = "PlayerBullet";

    public static string ANIMATION_IDLE = "idle";
    public static string ANIMATION_RUN = "run";
    public static string ANIMATION_WALK = "walk";
    public static string ANIMATION_JUMP = "jump";
    public static string ANIMATION_JUMP_FALL = "jumpFall";
    public static string ANIMATION_JUMP_LAND = "jumpLand";
    public static string ANIMATION_LEDGE_FALL = "ledgeFall";
}

public class GameObjects : MonoBehaviour
{
    public static string BACKGROUND = "Background";
    public static string LEVEL_GENERATOR = "Level Generator";
}