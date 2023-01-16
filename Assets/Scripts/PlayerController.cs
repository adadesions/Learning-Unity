using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Fields
	[SerializeField] float speed = 1.0f; // private
	[SerializeField] Transform m_camera;
	private Rigidbody m_rb;

	// Start is called before the first frame update
	// Methods
	void Start()
	{
		m_rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Movements();
	}

	private void Movements()
	{
		Vector3 input = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Vector3 diraction = input.normalized;

		if (input.magnitude > 0) {
			float targetAngle = Mathf.Atan2(diraction.x, diraction.z) * Mathf.Rad2Deg + m_camera.eulerAngles.y;

			m_rb.MoveRotation(Quaternion.Euler(0, targetAngle, 0));

			Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
			m_rb.MovePosition(m_rb.position + speed * Time.fixedDeltaTime * moveDir);
		}
	}
}
