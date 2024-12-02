using UnityEngine;
using System;
[CreateAssetMenu(fileName = "FishingRod", menuName = "Scriptable Objects/FishingRod")]
public class FishingRod : ScriptableObject
{
    System.Random random = new();
    [SerializeField] private int minWaitTime = 3;
    [SerializeField] private int maxWaitTime = 5;
    public GameObject Hook;
    public GameObject Tip;
    public float WaitTime => random.Next(minWaitTime, maxWaitTime);
    public Vector3 FishDirection => fishDirections[random.Next(0, 9)];

    private Vector2[] fishDirections = {
            new Vector2(0, 1), //down
            new Vector2(1, 1), //down right
            new Vector2(1, 0), //right
            new Vector2(1, -1), //right up
            new Vector2(0, -1), //up
            new Vector2(-1,-1), //up left
            new Vector2(-1, 0), //left
    };
}
