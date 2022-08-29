using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform ThingToFollow;

    // LateUpdate() en cámara para que siga al jugador después de moverse
    // y no tengan problemas de coordinación
    void LateUpdate()
    {
        transform.position = ThingToFollow.position + new Vector3(0, 0, -10);
    }
}
