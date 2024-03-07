using UnityEngine;

public class ScoreSurfaces : MonoBehaviour
{
    [SerializeField] private GameController.PlayerType _playerType;
    
    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent("Ball")) return;

        EventsSystem.FirePlayerScored(_playerType);
    }
}