using UnityEngine;

public static class MathUtils
{
    public static int OneMinus(this int value)
    {
        return 1 - value;
    }

    public static float OneMinus(this float value)
    {
        return 1f - value;
    }

    public static float Remap(this float value, float inMin, float inMax, float outMin, float outMax)
    {
        //return (value - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
        var alpha = Mathf.InverseLerp(inMin, inMax, value);

        return Mathf.Lerp(outMin, outMax, alpha);
    }

    public static float GetAngleFromVector(Vector3 vector)
    {
        vector = vector.normalized;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        
        if (angle < 0)
            angle += 360;

        return angle;
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * Mathf.Deg2Rad;

        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}