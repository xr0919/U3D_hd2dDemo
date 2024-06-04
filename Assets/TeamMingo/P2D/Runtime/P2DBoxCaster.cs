using UnityEngine;

namespace TeamMingo.P2D.Runtime
{
  public class P2DBoxCaster : P2DCaster
  {
    public BoxCollider2D box;

    protected override LayerMask GetCastingMask()
    {
      return LayerMask.GetMask("Default");
    }

    protected override PhysicsUtils.RaycastHit2DResult Cast(PhysicsUtils.RaycastHit2DResult result, Vector2 offset)
    {
      return Cast(result, offset, direction);
    }
    
    protected virtual PhysicsUtils.RaycastHit2DResult Cast(PhysicsUtils.RaycastHit2DResult result, Vector2 offset, Vector2 overrideDirection)
    {
      PhysicsUtils.BoxCast(result, box, overrideDirection, Filter, distance, offset, maxHits);
      return result;
    }
  }
}