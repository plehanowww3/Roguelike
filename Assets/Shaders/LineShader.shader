Shader "Custom/2DLineShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _PointA ("Point A", Vector) = (0,0,0,0)
        _PointB ("Point B", Vector) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };

            float4 _PointA;
            float4 _PointB;
            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            void frag (v2f i, out fixed4 oColor : COLOR)
            {
                float2 p = (i.pos.xy / i.pos.w + 1) * 0.5;
                float2 distA = abs(_PointA.xy - p);
                float2 distB = abs(_PointB.xy - p);
                float2 dist = abs(distA - distB);
                float d = max(dist.x, dist.y);
                float alpha = smoothstep(0.01, 0.05, d); // Указываем желаемую толщину линии здесь
                oColor = _Color * alpha;
            }
            ENDCG
        }
    }
}
