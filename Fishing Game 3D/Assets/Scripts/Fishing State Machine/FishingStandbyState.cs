using UnityEngine;

public class FishingStandbyState : FishingBaseState
{
    public override void EnterState()
    {
        Debug.Log("Standby");
    }

    public override void UpdateState(FishingStateManager manager, FishingRod fishingRod)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            manager.SwitchState(manager.Casting);
        }
    }
}
