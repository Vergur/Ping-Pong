using UnityEngine;

public class HandlePlayerInput : MonoBehaviour
{
    [SerializeField] private Plate _playerPlate;
    private Vector2 _direction;
    private PlayerInput _input;
    private enum Direction { Up, Down }
    
    private void Start()
    {
        _input = new PlayerInput();
        _input.Enable();

        _input.Player.MoveUp.started += ctx => Move(Direction.Up);
        _input.Player.MoveUp.canceled += ctx => Release();
        _input.Player.MoveDown.started += ctx => Move(Direction.Down);
        _input.Player.MoveDown.canceled += ctx => Release();
    }

    private void Move(Direction direction)
    {
        this._direction = direction switch
        {
            Direction.Up => Vector2.up,
            Direction.Down => Vector2.down,
            _ => this._direction
        };
        
        _playerPlate.ChangePlateDirection(_direction);
    }
    
    private void Release()
    {
        _direction = Vector2.zero;
        _playerPlate.ChangePlateDirection(_direction);
    }
}
