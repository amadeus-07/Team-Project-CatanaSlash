using Core;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

public class PlayerMovement : MonoBehaviour
{
    private IMovement movement;
    [Inject] PlayerInput Input { get; set; }

    void Awake()
    {
        movement = new NavMeshMovement(GetComponent<NavMeshAgent>(), true);
    }

    void Update()
    {
        var speed = 10;
        movement.Move(
            new Vector3(Input.Move.Value.x, 0, Input.Move.Value.y) * speed * Time.deltaTime
        );
    }

    
}
