using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TeamMingo.P2D.Runtime
{
  public static class PhysicsUtils
  {
    private static readonly RaycastHit2DResult SharedCastResult = new RaycastHit2DResult(4);
    private static readonly Overlap2DResults SharedOverlapResult = new Overlap2DResults(4);
    
    public class RaycastHit2DResult
    {
      public RaycastHit2D[] Results;
      public bool HasHits => Hits > 0;
      public int Hits;

      public RaycastHit2DResult(int initialSize)
      {
        Results = new RaycastHit2D[initialSize];
      }

      public void Resize(int size)
      {
        if (Results.Length < size)
        {
          Results = new RaycastHit2D[size];
        }
      }
      
      public T Find<T>(Func<Collider2D, T> predicate) where T : Object
      {
        if (!HasHits) return null;
        for (var i = 0; i < Hits; i++)
        {
          var found = predicate(Results[i].collider);
          if (found)
          {
            return found;
          }
        }

        return null;
      }
    }
    
    public class Overlap2DResults
    {
      public Collider2D[] Results;
      public bool HasHits => Hits > 0;
      public int Hits;

      public Overlap2DResults(int initialSize)
      {
        Results = new Collider2D[initialSize];
      }

      public void Resize(int size)
      {
        if (Results.Length < size)
        {
          Results = new Collider2D[size];
        }
      }

      public T Find<T>(Func<Collider2D, T> predicate) where T : Object
      {
        if (!HasHits) return null;
        for (var i = 0; i < Hits; i++)
        {
          var found = predicate(Results[i]);
          if (found)
          {
            return found;
          }
        }

        return null;
      }
    }

    public static Overlap2DResults CircleOverlap(
      Vector2 center, 
      float radius, 
      ContactFilter2D filter,
      int hits = 4)
    {
      SharedOverlapResult.Resize(hits);
      var count = Physics2D.OverlapCircle(center, radius, filter, SharedOverlapResult.Results);
      SharedOverlapResult.Hits = count;
      return SharedOverlapResult;
    }

    public static void Raycast(
      RaycastHit2DResult result,
      Vector2 origin,
      Vector2 direction,
      ContactFilter2D filter,
      float distance,
      int hits = 4)
    {
      result.Resize(hits);
      var count = Physics2D.defaultPhysicsScene.Raycast(origin, direction, distance, filter, result.Results);
      result.Hits = count;
    }

    public static void BoxCast(
      RaycastHit2DResult result,
      BoxCollider2D boxCollider2D,
      Vector2 direction,
      ContactFilter2D filter,
      float distance,
      Vector2 customOffset,
      int hits = 4)
    {
      var offset = boxCollider2D.offset + customOffset;
      var position = boxCollider2D.transform.position;
      var origin = new Vector2(offset.x + position.x, offset.y + position.y);
      var size = boxCollider2D.size + Vector2.one * 2 * boxCollider2D.edgeRadius;
      result.Resize(hits);
      var count = Physics2D.BoxCast(
        origin,
        size,
        0, direction,
        filter,
        result.Results,
        distance
      );
      result.Hits = count;
    }

    public static RaycastHit2DResult BoxCast(
      BoxCollider2D boxCollider2D, 
      Vector2 direction,
      ContactFilter2D filter, 
      float distance,
      Vector2 customOffset,
      int hits = 4)
    {
      BoxCast(SharedCastResult, boxCollider2D, direction, filter, distance, customOffset, hits);
      return SharedCastResult;
    } 
  }
}