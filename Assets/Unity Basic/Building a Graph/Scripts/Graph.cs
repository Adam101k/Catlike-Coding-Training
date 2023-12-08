using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    Transform[] points;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField]
    Functionlibrary.FunctionName function;

    // X coordinates handled here because they won't change
    void Awake()
    {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;

        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    // Y coordinates handled here because they'll be updating constantly
    void Update ()
    {
        Functionlibrary.Function f = Functionlibrary.GetFunction(function);
        float time = Time.time;
        for (int i = 0; i < points.Length;i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = f(position.x, time);
            point.localPosition = position;
        }
    }
}
