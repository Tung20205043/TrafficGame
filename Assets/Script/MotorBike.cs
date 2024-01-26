using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MotorBike : CarController
{
    [SerializeField] protected GameObject transport;
    public GameObject Transport => transport;
    private float zRangeMin = 4.2f;
    private float zRangeMax = 15.5f;
    public static Transform playerPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transport.transform;
        Move();

    }
    public override void Move() {
            if (Input.GetKey(KeyCode.W)) {
                transport.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S)) {
                transport.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D)) {
                transport.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A)) {
                transport.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }

            float zPosition = transport.transform.position.z;
            zPosition = Mathf.Clamp(zPosition, zRangeMin, zRangeMax);
            transport.transform.position = new Vector3(transport.transform.position.x, transport.transform.position.y, zPosition);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Traffic")) {
            Debug.Log("Sai quy tắc giao thông! Vui lòng quay lại và đợi đèn xanh.");
        }
        if (other.CompareTag("CaB")) {
            Debug.Log("Đây là phan duong cho ca 2 xe");
        }
        if (other.CompareTag("CarOnly")) {
            Debug.Log("Day la phan duong cho o to");
        }
        if (other.CompareTag("RightWay")) {
            Debug.Log("Ban da di dung duong");
        }
        if (other.CompareTag("WrongWay")) {
            Debug.Log("Ban da di sai duong ");
        }
        if (other.CompareTag("RandomCar")) {
            Debug.Log("Tai nan giao thong ");
        }
    }
}
