using System;
using Unity.VisualScripting;

public class EventsSystem
{
    public static Action<GameController.PlayerType> OnPlayerScored;
    public static void FirePlayerScored(GameController.PlayerType playerType)
    {
        OnPlayerScored?.Invoke(playerType);
    }
}