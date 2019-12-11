Shader "Custom/StoryImage"
{
 
    Properties {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
		_Mode ("Mode", Int) = 1
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
			int _Mode;

            VertexOutput vert (VertexInput input) {
            	VertexOutput output;
            	output.v = UnityObjectToClipPos(input.pos);
            	output.uv = input.uv;

            	//もとの色(SpriteRendererのColor)と設定した色(TintColor)を掛け合わせる
            	output.color = input.color * _Color; 

            	return output;
            }

            float4 frag (VertexOutput output) : SV_Target {
            	float4 c = tex2D(_MainTex, output.uv) * output.color;


				switch(_Mode){
					case 1:
					break;
					case 2:
					c.rgb=(c.rgb/2.0f);
					break;
					case 3:
					c.a=0;
					break;
				}



                c.rgb *= c.a;
                return c;
            }
        ENDCG
        }
    }

}
