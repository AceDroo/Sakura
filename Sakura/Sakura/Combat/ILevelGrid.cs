using Sakura.Core;
using Sakura.Functional;
using Sakura.Grid;
using Sakura.Interactions;

namespace Sakura.Combat;

public interface ILevelGrid
{
    void AddUnitAtGridPosition(GridPosition position, IUnit unit);
    void RemoveUnitAtGridPosition(GridPosition position, IUnit unit);
    Option<IUnit> GetUnitAtGridPosition(GridPosition position);
    bool IsValidGridPosition(GridPosition position);
    int Width { get; }
    int Height { get; }
    Option<IInteractable> GetInteractableAtGridPosition(GridPosition position);
    void SetInteractableAtGridPosition(GridPosition position);
    void ClearInteractableAtGridPosition(GridPosition position);
    // GridPosition GetGridPosition(Vector3 worldPosition);
    // Vector3 GetWorldPosition(GridPosition position);
}