using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : CarController
{
    private SpawnManager spawnManager;
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();    
    }

    
    void Update()
    {
        if (MotorBike.playerPosition.position.x > this.transform.position.x) {
            if (spawnManager != null) {
                spawnManager.DeSpawn(this.gameObject);
            }
        }
        Move();
    }

    public override void Move() {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
