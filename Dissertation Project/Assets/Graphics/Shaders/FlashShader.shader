Shader "Unlit/FlashShader"
{
    // used as a shader to flash the objects within a room
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FlashColor("Flash Color", Color) = (1,1,1,1)
        _isFlashing("Is Flashing", Range(0,1)) = 0
        _BaseColour("Base Color", Color) = (0.5,0.5,0.5,1)
        _CurrentColour("Current Colour", Color) = (0,0,0,0) 
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _FlashColor;
            float _isFlashing;
            float4 _CurrentColour;
            float4 _BaseColour;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float flashPercent = sin(_Time.w * 0.8);
                // sample the texture
            fixed4 col;
            if (_isFlashing > 0 & flashPercent > 0) {
                col = _BaseColour + (flashPercent * _FlashColor);
            }
            else {
                col = _BaseColour;
            }
            _CurrentColour = col;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
