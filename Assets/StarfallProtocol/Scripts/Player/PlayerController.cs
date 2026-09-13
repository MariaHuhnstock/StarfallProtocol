using UnityEngine;

namespace StarfallProtocol.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 6f;
        [SerializeField] private Vector2 _screenPadding = new Vector2(0.5f, 0.5f);

        private Rigidbody2D _rb;
        private Camera _mainCamera;
        private Vector2 _moveInput;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _moveInput.x = Input.GetAxisRaw("Horizontal");
            _moveInput.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            Vector2 newPosition = _rb.position + _moveInput.normalized * _moveSpeed * Time.fixedDeltaTime;
            newPosition = ClampToScreen(newPosition);
            _rb.MovePosition(newPosition);
        }

        private Vector2 ClampToScreen(Vector2 position)
        {
            Vector3 viewportPos = _mainCamera.WorldToViewportPoint(position);
            viewportPos.x = Mathf.Clamp01(viewportPos.x);
            viewportPos.y = Mathf.Clamp01(viewportPos.y);

            Vector3 clampedWorld = _mainCamera.ViewportToWorldPoint(viewportPos);
            return new Vector2(clampedWorld.x, clampedWorld.y);
        }
    }
}