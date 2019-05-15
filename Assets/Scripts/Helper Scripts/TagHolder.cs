using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis :MonoBehaviour
{
    public const string HORIZONTAL="Horizontal";
    public const string VERTICAL="Vertical";
    
}

public class MouseAxis:MonoBehaviour
{
    public const string MOUSEX="Mouse X";
    public const string MOUSEY="Mouse Y";
}

public class AnimationTags : MonoBehaviour
{
    public const string STEADYAIM_IN="SteadyAimIn";
    public const string STEADYAIM_OUT="SteadyAimOut";
    public const string ATTACK_PARAMETER="Attack";
    public const string AIM_TRIGGER="Aim";
    public const string ATTACK_TRIGGER="Attack";
    public const string WALK_TRIGGER="Walk";
    public const string RUN_TRIGGER="Run";
    public const string DEAD_TRIGGER="Dead"; 
    public const string HIT_TRIGGER="Hit";
}

public class Tags:MonoBehaviour
{
    public const string LOOK_ROOT="Look Root";
    public const string ZOOM_CAMERA="FP Camera";
    public const string CROSSHAIR="Crosshair";
    public const string AXE_TAG="Axe";
    public const string PLAYER_TAG="Player";
    public const string ENEMY_TAG="Enemy";
}