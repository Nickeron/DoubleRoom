using UnityEngine;

public abstract class PlayerInteract : MonoBehaviour
{
    protected bool makesPlayerWin;
    [SerializeField] RemovePlayerFunction onRemovePlayer;
    [SerializeField] ParticleSystem contactParticles;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player)
        {
            onRemovePlayer.Raise(new PlayerRemoval { player = player, isWinner = makesPlayerWin});
            contactParticles.Play();
        }
    }
}
