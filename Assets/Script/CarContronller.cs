using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour {
    protected float moveSpeed = 10f;
    public float MoveSpeed => moveSpeed;

    void Start() {

    }

    void Update() {
        Move();
    }

    public virtual void Move() {
    }

}
    
