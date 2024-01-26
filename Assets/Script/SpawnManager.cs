using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform holder;
    [SerializeField] protected GameObject[] objectToSpawn;
    [SerializeField] protected List<GameObject> poolObj;
    protected float zPosition;
    private float randomType;

    public static float difficult = 4f;
    void Start() {
        StartCoroutine(SpawnObjectRoutine());
    }
    void Update() {
    }

    IEnumerator SpawnObjectRoutine() {
        while (true) {
            yield return new WaitForSeconds(difficult); 
            SpawnObject();
        }
    }
    void SpawnObject() {
        randomType = Random.Range(1, 3);
        zPosition = Random.Range(6, 15);
        Vector3 spawnPoint = new Vector3 (MotorBike.playerPosition.position.x + 60,
            MotorBike.playerPosition.position.y, zPosition);
        Quaternion spawnRotation = Quaternion.Euler(0f, -90f, 0f);
        GetObjectFromBool(objectToSpawn[(int)randomType], spawnPoint, spawnRotation);
    }

    protected void GetObjectFromBool(GameObject _poolObj, Vector3 spawnPoin, Quaternion spawnRotation ) {
        if (poolObj.Count > 0) {
            foreach (GameObject poolObj in poolObj) {
                if (poolObj.name == _poolObj.name) {
                    this.poolObj.Remove(poolObj);
                    poolObj.transform.position = spawnPoin;
                    poolObj.SetActive(true);
                    poolObj.transform.parent = holder; 
                    return;
                }
            }
        }
        GameObject newPoolObj = Instantiate(_poolObj);
        newPoolObj.name = _poolObj.name;
        newPoolObj.transform.parent = holder;

    }
    public void DeSpawn(GameObject _poolObj) {
        poolObj.Add(_poolObj);
        _poolObj.SetActive(false);
    }
}
