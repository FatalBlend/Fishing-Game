using UnityEngine;

public class FishingStateManager : MonoBehaviour
{
    public FishingRod fishingRod;
    private FishingBaseState currentState;
    public FishingStandbyState Standby = new();
    public FishingCastingState Casting = new();

    [SerializeField] private GameObject hook;
    [SerializeField] private GameObject tip;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        fishingRod.Hook = hook;
        fishingRod.Tip = tip;        
    }
    private void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SwitchState(Standby);
    }
    public void SwitchState(FishingBaseState state)
    {
        currentState = state;
        currentState.EnterState();
    }

    private void Update()
    {
        currentState.UpdateState(this, fishingRod);

    }
    private void LateUpdate()
    {
        lineRenderer.SetPositions(new Vector3[] { tip.transform.position, hook.transform.position });
    }
}
