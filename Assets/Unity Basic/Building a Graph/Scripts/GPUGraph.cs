using UnityEngine;

public class GPUGraph : MonoBehaviour
{
    [SerializeField, Range(10, 200)]
    int resolution = 10;

    [SerializeField]
    Functionlibrary.FunctionName function;

    public enum TransitionMode { Cycle, Random }

    [SerializeField]
    TransitionMode transitionMode = TransitionMode.Cycle;

    [SerializeField, Min(0f)]
    float functionDuration = 1f, transitionDuration = 1f;

    //Transform[] points;

    float duration;

    bool transitioning;

    Functionlibrary.FunctionName transitionFunction;

    void Update()
    {
        duration += Time.deltaTime;
        if (transitioning)
        {
            if (duration >= transitionDuration)
            {
                duration -= transitionDuration;
                transitioning = false;
            }
        }
        else if (duration >= functionDuration)
        {
            duration -= functionDuration;
            transitioning = true;
            transitionFunction = function;
            PickNextFunction();
        }
    }
    void PickNextFunction()
    {
        function = transitionMode == TransitionMode.Cycle ?
            Functionlibrary.GetNextFunctionName(function) :
            Functionlibrary.GetRandomFunctionNameOtherThan(function);
    }
}
