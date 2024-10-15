using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Movement")]
public class PlayerMovement : ScriptableObject
{
    [Header("Walk")]
    [Range(1f, 100f)] public float maxWalkSpeed = 12.5f;
    [Range(0.25f, 50f)] public float GroundAcceleration = 5f;
    [Range(0.25f, 50f)] public float GroundDecceleration = 20f;
}
