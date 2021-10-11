using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDirection
{
    front,
    behind,
    left,
    right,
    up,
    down,
}

public static class EDirectionExtensions
{
    public static Vector3 DirectionToV3(this EDirection eDirection)
    {
        switch(eDirection)
        {
            case EDirection.up:
                {
                    return Vector3.zero;
                }
            case EDirection.down:
                {
                    return new Vector3(180f, 0f, 0f);
                }
            case EDirection.left:
                {
                    return new Vector3(-90f, 0f, 0f);
                }
            case EDirection.right:
                {
                    return new Vector3(90f, 0f, 0f);
                }
            case EDirection.front:
                {
                    return new Vector3(0f, 0f, 90f);
                }
            case EDirection.behind:
                {
                    return new Vector3(0f, 0f, -90f);
                }

        }

        return Vector3.zero;
    }
}
