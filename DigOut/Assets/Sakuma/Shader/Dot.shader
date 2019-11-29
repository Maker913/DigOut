 
Shader "Custom/Dot" {
    Properties {
        _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		_Rim("Rim", Range(0,1)) = 0
		_X("_X",int) = 0
		_Y("_Y", int) = 0
    }

    SubShader{
        Tags { 
            "Queue"="Transparent"
        }
       
	ZWrite Off
        Blend One OneMinusSrcAlpha //乗算済みアルファ

        Pass {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct VertexInput {
                float4 pos	:	POSITION;    // 3D座標
                float4 color:	COLOR;
                float2 uv	:	TEXCOORD0;   // テクスチャ座標
            };

            struct VertexOutput {
                float4 v	:	SV_POSITION; // 2D座標
                float4 color:	COLOR;	
                float2 uv	:   TEXCOORD0;   // テクスチャ座標
            };

            //プロパティの内容を受け取る
            float4 _Color;
            sampler2D _MainTex;
			float _Rim;
			int _X;
			int _Y;


            VertexOutput vert (VertexInput input) {
            	VertexOutput output;
            	output.v = UnityObjectToClipPos(input.pos);
            	output.uv = input.uv;

            	//もとの色(SpriteRendererのColor)と設定した色(TintColor)を掛け合わせる
            	output.color = input.color * _Color; 

            	return output;
            }

            float4 frag (VertexOutput output) : SV_Target {

				//float2 data = float2((int)(output.uv.x / _X)*_X,(int)(output.uv.y / _Y)*_Y);


				float2 dat = output.uv;

				for (int i = 0; i < _X; i++) {
					if (output.uv.x < (float)i / _X) {
						dat.x = (float)i / _X;
						break;
					}
				}

				for (int i = 0; i < _Y; i++) {
					if (output.uv.y <(float) i / _Y) {
						dat.y = (float)i / _Y;
						break;
					}
				}
				

            	float4 c =tex2D(_MainTex, dat);


				c.r = floor(c.r * 10) / 10;
				c.g = floor(c.g * 10) / 10;
				c.b = floor(c.b * 10) / 10;

                c.rgb *= c.a;
                return c;
            }
        ENDCG
        }
    }
}