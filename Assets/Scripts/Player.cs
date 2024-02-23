using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public PlayerRotation RotationMechanic;

    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        RotationMechanic = GetComponent<PlayerRotation>();
    }
}
