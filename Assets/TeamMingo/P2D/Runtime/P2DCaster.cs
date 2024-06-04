using System;
using UnityEngine;
using UnityEngine.Events;

namespace TeamMingo.P2D.Runtime
{
  public abstract class P2DCaster : MonoBehaviour
  {
    public float distance = 0.02f;
    public Vector2 direction = Vector2.right;
    public bool useTriggers;
    public int maxHits;

    public PhysicsUtils.RaycastHit2DResult Result { get; private set; }
    public UnityEvent<PhysicsUtils.RaycastHit2DResult> onCasterResultChange;

    protected ContactFilter2D Filter;
    private PhysicsUtils.RaycastHit2DResult _lastResult;


    protected virtual void Awake()
    {
      Filter = new ContactFilter2D
      {
        useTriggers = useTriggers,
        useLayerMask = true,
        layerMask = GetCastingMask()
      };
      Result = new PhysicsUtils.RaycastHit2DResult(maxHits);
      _lastResult = new PhysicsUtils.RaycastHit2DResult(maxHits);
    }

    protected abstract LayerMask GetCastingMask();

    protected abstract PhysicsUtils.RaycastHit2DResult Cast(PhysicsUtils.RaycastHit2DResult result, Vector2 offset);

    protected virtual void FixedUpdate()
    {
      BeforeProcessCast();
      ProcessCast();
      AfterProcessCast();
    }
    
    public virtual void BeforeProcessCast() {}
    public virtual void AfterProcessCast() {}

    public virtual void ProcessCast()
    {
      var result = Cast(Result, Vector2.zero);
      var equals = ResultEquals(_lastResult, result);
      
      if (!equals)
      {
        _lastResult.Hits = result.Hits;
        if (Result.Hits == 0)
        {
          result.Results = new RaycastHit2D[maxHits];
        }
        else
        {
          result.Results.CopyTo(_lastResult.Results, 0);
        }
        onCasterResultChange.Invoke(Result);
      }
      
      ProcessResult(result);
    }
    
    protected virtual void ProcessResult(PhysicsUtils.RaycastHit2DResult result) {}

    protected virtual bool ResultEquals(PhysicsUtils.RaycastHit2DResult resultA, PhysicsUtils.RaycastHit2DResult resultB)
    {
      var hitsEq = resultA.Hits == resultB.Hits;
      if (!hitsEq) return false;
      
      if (maxHits == 1)
      {
        return HitEquals(resultA.Results[0], resultB.Results[0]);
      }

      Array.Sort(resultA.Results, (a, b) => a.collider.name.GetHashCode() - b.collider.name.GetHashCode());
      Array.Sort(resultB.Results, (a, b) => a.collider.name.GetHashCode() - b.collider.name.GetHashCode());
      
      for (var i = 0; i < resultA.Hits; i++)
      {
        if (!HitEquals(resultA.Results[i], resultB.Results[i]))
        {
          return false;
        }
      }

      return true;
    }

    protected virtual bool HitEquals(RaycastHit2D hitA, RaycastHit2D hitB)
    {
      return hitA.collider == hitB.collider;
    }
  }
}