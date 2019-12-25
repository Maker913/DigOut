Shader "Custom/Break"
{
   Properties {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)


		_pt1("_pt1",Vector)=(0,0,0,0)
		_pt2("_pt2",Vector)=(0,0,0,0)
		_pt3("_pt3",Vector)=(0,0,0,0)
		_pt4("_pt4",Vector)=(0,0,0,0)
		_pt5("_pt5",Vector)=(0,0,0,0)
		_pt6("_pt6",Vector)=(0,0,0,0)
		_pt7("_pt7",Vector)=(0,0,0,0)
		_pt8("_pt8",Vector)=(0,0,0,0)
		_pt9("_pt9",Vector)=(0,0,0,0)

		[MaterialToggle] _IsHoge ("Is Hoge", Float) = 0
		_Fade("_Fade",Range(0,1))=1
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

			float4 _pt1;
			float4 _pt2;
			float4 _pt3;
			float4 _pt4;
			float4 _pt5;
			float4 _pt6;
			float4 _pt7;
			float4 _pt8;
			float4 _pt9;

			int _target;

			float _IsHoge;
			float _Fade;

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

				float dis[9]=
				{
				sqrt(pow(_pt1.x-output.uv.x,2)+pow(_pt1.y-output.uv.y,2)),
				sqrt(pow(_pt2.x-output.uv.x,2)+pow(_pt2.y-output.uv.y,2)),
				sqrt(pow(_pt3.x-output.uv.x,2)+pow(_pt3.y-output.uv.y,2)),
				sqrt(pow(_pt4.x-output.uv.x,2)+pow(_pt4.y-output.uv.y,2)),
				sqrt(pow(_pt5.x-output.uv.x,2)+pow(_pt5.y-output.uv.y,2)),
				sqrt(pow(_pt6.x-output.uv.x,2)+pow(_pt6.y-output.uv.y,2)),
				sqrt(pow(_pt7.x-output.uv.x,2)+pow(_pt7.y-output.uv.y,2)),
				sqrt(pow(_pt8.x-output.uv.x,2)+pow(_pt8.y-output.uv.y,2)),
				sqrt(pow(_pt9.x-output.uv.x,2)+pow(_pt9.y-output.uv.y,2))
				};


				float leng=sqrt(2);
				int num=-1;


				for(int i=0;i<9;i++){
					if(dis[i]<leng)
					{
						num=i;
						leng=dis[i];
					}
				}

				if(_IsHoge==1)
				{
					switch(num)
					{
					case 0:
						c=float4(0,1,1,1);
						break;
					case 1:
						c=float4(0,0,1,1);
						break;
					case 2:
						c=float4(0,1,0,1);
						break;
					case 3:
						c=float4(0,0,0,1);
						break;
					case 4:
						c=float4(1,0,1,1);
						break;
					case 5:
						c=float4(1,0,0,1);
						break;
					case 6:
						c=float4(1,1,0,1);
						break;
					case 7:
						c=float4(0.5f,1,1,1);
						break;
					case 8:
						c=float4(1,0.5f,1,1);
						break;
					}
				}
				


				c.a=num==_target?_Fade:0;





                c.rgb *= c.a;
                return c;
            }
        ENDCG
        }
    }
}
