using Unity.VisualScripting;
using UnityEngine;

public abstract class FishingBaseState
{
    public abstract void EnterState();
    public abstract void UpdateState(FishingStateManager manager, FishingRod fishingRod);
}
