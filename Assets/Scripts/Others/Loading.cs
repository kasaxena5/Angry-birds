using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class Loading : MonoBehaviour
{
    [SerializeField] private RectTransform pointPrefab;
    [SerializeField, Range(10, 100)] private int resolution = 10;
    [SerializeField] private ParametricFunctionName function;

    private RectTransform[] points;

    private void Awake()
    {
        points = new RectTransform[resolution];
        float step = 2f / resolution;
        for (int i = 0; i < resolution; i++)
        {
            RectTransform point = Instantiate(pointPrefab);
            point.sizeDelta *= step;
            point.SetParent(transform, false);
            points[i] = point;    
        }
    }

    void Update()
    {
        ParametricFunction f = GetParametricFunction(function);
        float step = 2f / resolution;
        for (int i = 0; i < resolution; i++)
        {
            float u = (i + 0.5f) * step - 1f;
            RectTransform point = points[i];
            point.anchoredPosition = f(u, Time.time);
            
        }
    }


    public delegate Vector2 ParametricFunction(float u, float t);

    public enum ParametricFunctionName { Wave }

    static ParametricFunction[] parametricFunctions = { Wave };

    public static ParametricFunction GetParametricFunction(ParametricFunctionName name)
    {
        return parametricFunctions[(int)name];
    }

    public static Vector2 Wave(float u, float t)
    {
        Vector2 p;
        float A = 50f;
        float w = 0.25f;
        p.x = (A + (A/2) * Sin (PI * (u + w * t))) * Cos(PI * (u + w * t));
        p.y = (A + (A/2) * Sin(PI * (u + w * t))) * Sin(PI * (u + w * t));
        return p;
    }
}
