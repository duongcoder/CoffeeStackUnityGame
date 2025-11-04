using UnityEngine;
using UnityEngine.InputSystem;

public class LaneMoverNew : MonoBehaviour
{
    public Transform[] lanes;
    public float forwardSpeed = 6f;
    public float laneChangeSpeed = 10f;

    private Controls controls;
    private int currentLane = 1;
    private Vector3 targetPos;

    void Awake()
    {
        controls = new Controls();
        controls.Player.MoveLeft.performed += ctx => MoveLeft();
        controls.Player.MoveRight.performed += ctx => MoveRight();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        targetPos.x = lanes[currentLane].position.x;
        var pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetPos.x, laneChangeSpeed * Time.deltaTime);
        transform.position = pos;
    }

    void MoveLeft()
    {
        currentLane = Mathf.Max(0, currentLane - 1);
    }

    void MoveRight()
    {
        currentLane = Mathf.Min(lanes.Length - 1, currentLane + 1);
    }
}
