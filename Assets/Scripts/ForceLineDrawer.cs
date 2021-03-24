using UnityEngine;

[RequireComponent(typeof(LineRenderer))]


public class ForceLineDrawer : MonoBehaviour {

    [Tooltip("The percent of the line that is consumed by the arrowhead")] [Range(0, 1)]
    public float PercentHead = 0.4f;
    public bool disableActive;
    
    public Vector3 ArrowOrigin;
    public Vector3 ArrowTarget;
    
    public Transform ballPos;
    public InputState IS;
    public LineRenderer lineRenderer;

    // void Start() {
    //     UpdateArrow();
    // }
    //
    // private void OnValidate() {
    //     UpdateArrow();
    // }

    // Start is called before the first frame update
    private void Awake() {
        IS = GetComponentInParent<InputState>();
        ballPos = GetComponentInParent<Transform>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    [ContextMenu("UpdateArrow")]
    void LateUpdate() {
        if (IS.pressed) {
            
            lineRenderer.enabled = true;
            lineRenderer = this.GetComponent<LineRenderer>();
            Vector3 lineScale = IS.downPos - IS.currentPos;
            ArrowOrigin = ballPos.position + lineScale/100f;
            ArrowTarget = ArrowOrigin + lineScale;

            lineRenderer.widthCurve = new AnimationCurve(
                new Keyframe(0, 0.4f)
                , new Keyframe(0.999f - PercentHead, 0.4f) // neck of arrow
                , new Keyframe(1 - PercentHead, 1f) // max width of arrow head
                , new Keyframe(1, 0f)); // tip of arrow
            lineRenderer.SetPositions(new Vector3[] {
                ArrowOrigin, Vector3.Lerp(ArrowOrigin, ArrowTarget, 0.999f - PercentHead),
                Vector3.Lerp(ArrowOrigin, ArrowTarget, 1 - PercentHead), ArrowTarget
            });
        }else {
            if(disableActive)
                lineRenderer.enabled = false;
        }
    }

    // Update is called once per frame

}