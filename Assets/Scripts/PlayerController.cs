using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float movementSpeed = 12;
	public float turningSpeed = 60;
	private Rigidbody rb;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
	}
    void Update() {
		transform.rotation = Camera.main.transform.rotation;

		float vertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(0, 0, vertical);

		rb.AddRelativeForce(movement * movementSpeed);
	}
}