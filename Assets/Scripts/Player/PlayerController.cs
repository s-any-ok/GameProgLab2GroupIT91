using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rb;
		[SerializeField] private Transform _camera;
	
		[SerializeField] private float distance = 10;
		[SerializeField] private float sensitivity = 3;

		private Vector3 _cameraOffset;
	
		private void Start()
		{
			_cameraOffset = (Vector3.up + Vector3.back).normalized * distance;
		}

		private void FixedUpdate()
		{
			float horizontalInput = Input.GetAxis("Horizontal");
			float verticalInput = Input.GetAxis("Vertical");

			Vector3 verticalMovement = new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z);
			Vector3 horizontalMovement = new Vector3(_camera.transform.right.x, 0, _camera.transform.right.z);
			Vector3 movement = horizontalInput * horizontalMovement.normalized + verticalInput * verticalMovement.normalized;

			_rb.AddForce(movement.normalized, ForceMode.VelocityChange);
		}

		private void Update()
		{
			Vector2 cameraRotation = new Vector2(-Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X") * sensitivity);
			_cameraOffset = Quaternion.Euler(cameraRotation) * _cameraOffset;
			_camera.position = transform.position + _cameraOffset;
			_camera.forward = -_cameraOffset.normalized;
		}
	}
}
