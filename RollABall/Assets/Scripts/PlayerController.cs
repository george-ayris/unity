using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody _rb;
    private int _count;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
         SetCountText();
        WinText.text = String.Empty;
    }

    private void SetCountText()
    {
        CountText.text = string.Format("Count: {0}", _count);
        if (_count >= 12)
            WinText.text = "You win!";
    }

    void FixedUpdate ()
	{
	    float moveHorizontal = Input.GetAxis("Horizontal");
	    float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        _rb.AddForce(movement * Speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }
}
