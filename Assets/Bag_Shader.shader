Shader "Unlit/Bag_Shader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BagIntensity("Bag", 2D) = "white" {}
		_BagFullness("Ladung", range(0,1)) = 0.1 
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		LOD 100
		Cull Off 
		ZWrite Off 
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _BagIntensity;
			float _BagFullness;
			
			v2f vert (appdata i)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(i.vertex);
				o.uv = i.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float4 col = tex2D(_MainTex, i.uv);
				col.a *= step(1-_BagFullness, tex2D(_BagIntensity, i.uv).r);
				
				return col;

			}
			ENDCG
		}
	}
}
