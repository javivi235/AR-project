Shader "Unlit/Contorno2"
{
	Properties
	{
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = (108,226,18,1)
		_OutlineWidth("Outline width", Range(1.0,5.0)) = 1.03
	}

		CGINCLUDE
		#include "UnityCG.cginc"

		struct appdata
		{
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f
		{
			float4 pos : POSITION;
			float4 color : COLOR;
			float3 nomral : NORMAL;
		};

		float _OutlineWidth;
		float4 _OutlineColor;

		v2f vert(appdata v)
		{
			v.vertex.xyz *= _OutlineWidth;
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.color = _OutlineColor;
			return o;
		};

		ENDCG
	SubShader

	{
	Tags{"Queue" = "Transparent"}
		Pass
		{
			ZWrite Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			half4 frag(v2f i) : COLOR
			{
				return i.color;
			}
			ENDCG
		}
		Pass
		{
			ZWrite On

			Material
			{
				Diffuse[_Color]
				Ambient[_Color]
			}
			Lighting On
			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}
			SetTexture[_MainTex]
			{
				Combine previous * primary DOUBLE
			}
		}
	}
}