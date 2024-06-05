using System;
using UnityEngine;

namespace Core
{
    public class ShaderTest: MonoBehaviour
    {
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [SerializeField] private Material lineMaterial;

        private void Start()
        {
            // Добавляем основную текстуру в материал, если она не установлена
            if (lineMaterial != null && !lineMaterial.HasProperty("_MainTex"))
            {
                lineMaterial.SetTexture("_MainTex", Texture2D.whiteTexture);
            }
        }
        
        private void Update()
        {
            if (lineMaterial != null && pointA != null && pointB != null)
            {
                // Устанавливаем позиции точек в материале
                lineMaterial.SetVector("_PointA", pointA.position);
                lineMaterial.SetVector("_PointB", pointB.position);
            }
        }
    }
}