using UnityEngine;

public class FishingCastingState : FishingBaseState
{
    private float timer;
    public override void EnterState()
    {
        Debug.Log("Casting");
        timer = 0;
    }

    public override void UpdateState(FishingStateManager manager, FishingRod fishingRod)
    {
        timer += Time.deltaTime;

        //TODO:

        if (timer > fishingRod.WaitTime)
        {
            manager.SwitchState(manager.Standby);
        }
    }
}
