using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{ 
    [Header("Move")]
    public float walkSpeed = 4.5f;   // 走りなし。一定速度で歩く

    [Header("Mouse Look")]
    public Transform cameraPivot;    // Main Camera の Transform
    public float mouseSensitivity = 1.5f; //ここが感度
    public float minPitch = -85f;
    public float maxPitch = 85f;

    [Header("Misc")]
    public bool lockCursorOnPlay = true;

    private CharacterController cc;
    private float pitch;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        if (cameraPivot == null && Camera.main != null)
            cameraPivot = Camera.main.transform;

        if (lockCursorOnPlay) LockCursor(true);
    }

    void Update()
    {
        HandleMouseLook();
        HandleMove();
        HandleCursorToggle();
    }

    void HandleMouseLook()
    {
        Vector2 delta = ReadMouseDelta();
        float yaw = delta.x * mouseSensitivity;
        float pitchDelta = -delta.y * mouseSensitivity;

        // 水平回転は本体
        transform.Rotate(0f, yaw, 0f);

        // 垂直回転はカメラ
        pitch = Mathf.Clamp(pitch + pitchDelta, minPitch, maxPitch);
        if (cameraPivot) cameraPivot.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }

    void HandleMove()
    {
        //// WASD / 矢印キーでXZ平面のみ移動
        //Vector2 move = ReadMoveAxes();
        //Vector3 dir = (transform.right * move.x + transform.forward * move.y);
        //if (dir.sqrMagnitude > 1f) dir.Normalize();

        //// SimpleMove は内部で重力を自動適用（ジャンプなし）
        //cc.SimpleMove(dir * walkSpeed);
    }

    void HandleCursorToggle()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isLocked = Cursor.lockState == CursorLockMode.Locked;
            LockCursor(!isLocked);
        }
    }

    void LockCursor(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }

    // ===== 入力ラッパ =====
    Vector2 ReadMouseDelta()
    {
#if ENABLE_INPUT_SYSTEM
        if (UnityEngine.InputSystem.Mouse.current != null)
            return UnityEngine.InputSystem.Mouse.current.delta.ReadValue();
#endif
        return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    Vector2 ReadMoveAxes()
    {
#if ENABLE_INPUT_SYSTEM
        // 新Input Systemを使う場合はActionに合わせて置き換え可。
        // ここでは旧入力互換の簡易キー読みを併用。
#endif
        float x = 0f, y = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x += 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) y += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) y -= 1f;
        Vector2 v = new Vector2(x, y);
        return v.sqrMagnitude > 1f ? v.normalized : v;
    }
}