using System;
using _Scirpts;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float moveSpeed = 5f;

    [Inject] private InputService inputService;
    
    private void Update()
    {
        Vector2 input = inputService.PlayerInput.Player.Move.ReadValue<Vector2>();

        Vector3 move = new Vector3(input.x, 0, input.y);
        
        _characterController.Move(move * (moveSpeed * Time.deltaTime));
    }
}
