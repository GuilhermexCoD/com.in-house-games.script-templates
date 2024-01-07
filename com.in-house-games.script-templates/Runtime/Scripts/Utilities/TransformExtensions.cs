using UnityEngine;

public static class TransformExtensions
{
    public static bool IsInRange(this GameObject go, GameObject other, float maxRange) => IsInRange(go.transform, other.transform.position, maxRange);
    public static bool IsInRange(this Transform t, GameObject other, float maxRange) => IsInRange(t, other.transform.position, maxRange);
    public static bool IsInRange(this GameObject go, Transform t, float maxRange) => IsInRange(go.transform, t.position, maxRange);
    public static bool IsInRange(this Transform t, Transform other, float maxRange) => IsInRange(t, other.position, maxRange);
    public static bool IsInRange(this Transform t, Vector3 position, float maxRange)
    {
        return (t.position - position).sqrMagnitude <= maxRange * maxRange;
    }
}
