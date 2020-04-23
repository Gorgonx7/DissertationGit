Shader "Custom/FillShader"
{
	/// Used as a shader for filling the cup of tea
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
		_Fullness ("Fill", Range(0.4,1)) = 0.0
    }
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

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
					
					
					float4 vertex : SV_POSITION;
				};

				
				
				// color from the material
				fixed4 _Color;
				half _Fullness;
				v2f vert(appdata v)
				{
					v2f o;
					if (_Fullness == 0.4) {
						v.vertex *= 0;
					}
					else {
						v.vertex.z *= _Fullness;
					}
					o.vertex = UnityObjectToClipPos(v.vertex);
					
					
					
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{

					return _Color;
				}
				ENDCG
			}
		}
    FallBack "Diffuse"
}
