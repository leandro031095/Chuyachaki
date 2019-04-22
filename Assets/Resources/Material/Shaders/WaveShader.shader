Shader "Custom/WaveShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Wave("Wave", Range(0,200)) = 0
		_Velocity("Velocity",Range(0,10)) = 0
		_Opaqueness("Opaqueness", Range(0,1)) = 0.5
		_Red("Red",Range(0,1)) = 0
		_Green("Green",Range(0,1)) = 0
    }
    SubShader
    {
		Tags {   "Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}
		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

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
			half _Wave;
			half _Velocity;
			half _Opaqueness;
			half _Red;
			half _Green;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f IN) : SV_Target
            {
                // sample the texture

				float2 uv = IN.uv;

				//uv.y += sin(IN.vertex.x / 50 + _Time[1] * _Velocity) / _Wave;

                fixed4 col = tex2D(_MainTex, uv);

				col -= float4(_Opaqueness, _Opaqueness, _Opaqueness, 0);
				col.gb -= _Red;
				col.g += _Green;

				col.rgb *= col.a;

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
