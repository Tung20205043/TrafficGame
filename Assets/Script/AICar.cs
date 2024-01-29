
using UnityEngine;

public class AICar : CarController
{
    private SpawnManager spawnManager;
    protected float moveSpeed;
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();    
    }

    
    void Update()
    {
        switch (UImode.modeValue) {
            case 0:
                moveSpeed = 7;
                break;
            case 1:
                moveSpeed = 12;
                break;
            case 2:
                moveSpeed = 15;
                break;
        }
        if (MotorBike.playerPosition.position.x > this.transform.position.x) {
            if (spawnManager != null) {
                spawnManager.DeSpawn(this.gameObject);
            }
        }
        Move();
    }

    public override void Move() {
        if (!GameManager.continueGame) return;
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
