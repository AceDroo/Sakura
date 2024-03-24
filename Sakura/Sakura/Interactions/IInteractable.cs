namespace Sakura.Interactions;

public interface IInteractable
{
    bool TryInteract(IInteractableActor actor);
}