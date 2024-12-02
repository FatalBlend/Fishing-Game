using UnityEngine;

public class FishinRod : MonoBehaviour
{
    [SerializeField] private Transform hook;
    [SerializeField] private Transform tip;
    private Vector3[] points = new Vector3[2];
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        points[0] = hook.position;
        points[1] = tip.position;
        lineRenderer.SetPositions(points);
    }
}
