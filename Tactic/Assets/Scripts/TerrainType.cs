using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terrain/Terrain Type")]
public class TerrainType : ScriptableObject {


    [SerializeField]
    int walkingMovementCost;
    [SerializeField]
    int ridingMovementCost;
    [SerializeField]
    int flyingMovementCost;
    [SerializeField]
    int navegatingMovementCost;

    [Space]

    [SerializeField]
    int evacionModifier;
    [SerializeField]
    int defenseModifier;

    [Space]

    [SerializeField]
    bool isWalkable;
    [SerializeField]
    bool isRideable;
    [SerializeField]
    bool isFlyable;
    [SerializeField]
    bool isNavigable;


    

}
