using UnityEngine;

[RequireComponent(typeof(GameHandler))]
public class RemovePlayerListener : GameFunctionListener<PlayerRemoval>
{
    public override void OnEventRaised(PlayerRemoval removal)
    {
        GetComponent<GameHandler>().RemovePlayerFromList(removal);
    }
}

public struct PlayerRemoval
{
    public PlayerMovement player;
    public bool isWinner;
}
