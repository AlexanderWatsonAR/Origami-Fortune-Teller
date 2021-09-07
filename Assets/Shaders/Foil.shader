Shader "Foil"
    {
        Properties
        {
	     // Stencil Mask Stuff.
	    _StencilComp ("Stencil Comparison", Float) = 8
            _Stencil ("Stencil ID", Float) = 0
            _StencilOp ("Stencil Operation", Float) = 0
            _StencilWriteMask ("Stencil Write Mask", Float) = 255
            _StencilReadMask ("Stencil Read Mask", Float) = 255
            _ColorMask ("Color Mask", Float) = 15

            [NoScaleOffset]Texture2D_d4b614eb516544598b6e661a9d35ad31("MainTex", 2D) = "white" {}
            [NoScaleOffset]Texture2D_e9e6a9a58276426799e1092067d4f80d("SpectrumTex", 2D) = "white" {}
            [NoScaleOffset]Texture2D_b2322190bca94b94951c18f813f39dce("MetalicTex", 2D) = "white" {}
            [NoScaleOffset]Texture2D_4e2c1d09021f482495c450f712c62ff8("SparkleTex", 2D) = "white" {}
            [NoScaleOffset]Texture2D_79a684fb53ee4feab2ac94b51021af26("DiffractionMapTex", 2D) = "white" {}
            Vector1_f76a46c5eed947b3a2a735cc4bdb771a("Smoothness", Range(0, 1)) = 0
            Vector1_d2a96271474c46c5ab567d69750b0117("Luminosity", Range(0, 1)) = 0.5
            [ToggleUI]Boolean_9b9b8114641e4412b7507f2f263d2633("Toggle Diffraction", Float) = 1
            _Stencil("Stencil", Float) = 1
            Vector1_4bfce301afa743508565723be93dc6ed("Transparency", Range(0, 1)) = 1
            Color_a699c866f1d14065bc7b7abae9858103("OverlayColour", Color) = (1, 0, 0, 1)
        }
        SubShader
        {
            Tags
            {
                // RenderPipeline: <None>
                "RenderType"="Transparent"
                "Queue"="Transparent+0"
            }
            Pass
            {
		Stencil
		{
    	    	    Ref [_Stencil]
                    Comp [_StencilComp]
                    Pass [_StencilOp]
                    ReadMask 255
                    WriteMask 255
		}

		ColorMask [_ColorMask]
                // Name: <None>
                Tags
                {
                    // LightMode: <None>
                }
    
                // Render State
                // RenderState: <None>
    
                // Debug
                // <None>
    
                // --------------------------------------------------
                // Pass
    
                HLSLPROGRAM
    
                // Pragmas
                #pragma vertex vert
                #pragma fragment frag
    
                // DotsInstancingOptions: <None>
                // HybridV1InjectedBuiltinProperties: <None>
    
                // Keywords
                // PassKeywords: <None>
                // GraphKeywords: <None>
    
                // Defines
                #define ATTRIBUTES_NEED_NORMAL
                #define ATTRIBUTES_NEED_TANGENT
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_NORMAL_WS
                #define VARYINGS_NEED_TANGENT_WS
                #define VARYINGS_NEED_TEXCOORD0
                #define VARYINGS_NEED_VIEWDIRECTION_WS
                /* WARNING: $splice Could not find named fragment 'PassInstancing' */
                #define SHADERPASS SHADERPASS_PREVIEW
                #define SHADERGRAPH_PREVIEW
                /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */
    
                // Includes
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Packing.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/NormalSurfaceGradient.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
                #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/EntityLighting.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariables.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/ShaderVariablesFunctions.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/Functions.hlsl"
    
                // --------------------------------------------------
                // Structs and Packing
    
                struct Attributes
                {
                    float3 positionOS : POSITION;
                    float3 normalOS : NORMAL;
                    float4 tangentOS : TANGENT;
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct Varyings
                {
                    float4 positionCS : SV_POSITION;
                    float3 normalWS;
                    float4 tangentWS;
                    float4 texCoord0;
                    float3 viewDirectionWS;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float3 WorldSpaceNormal;
                    float3 WorldSpaceTangent;
                    float3 WorldSpaceViewDirection;
                    float4 uv0;
                };
                struct VertexDescriptionInputs
                {
                };
                struct PackedVaryings
                {
                    float4 positionCS : SV_POSITION;
                    float3 interp0 : TEXCOORD0;
                    float4 interp1 : TEXCOORD1;
                    float4 interp2 : TEXCOORD2;
                    float3 interp3 : TEXCOORD3;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                    #endif
                };
    
                PackedVaryings PackVaryings (Varyings input)
                {
                    PackedVaryings output;
                    output.positionCS = input.positionCS;
                    output.interp0.xyz =  input.normalWS;
                    output.interp1.xyzw =  input.tangentWS;
                    output.interp2.xyzw =  input.texCoord0;
                    output.interp3.xyz =  input.viewDirectionWS;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    output.cullFace = input.cullFace;
                    #endif
                    return output;
                }
                Varyings UnpackVaryings (PackedVaryings input)
                {
                    Varyings output;
                    output.positionCS = input.positionCS;
                    output.normalWS = input.interp0.xyz;
                    output.tangentWS = input.interp1.xyzw;
                    output.texCoord0 = input.interp2.xyzw;
                    output.viewDirectionWS = input.interp3.xyz;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    output.instanceID = input.instanceID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    output.cullFace = input.cullFace;
                    #endif
                    return output;
                }
    
                // --------------------------------------------------
                // Graph
    
                // Graph Properties
                CBUFFER_START(UnityPerMaterial)
                float4 Texture2D_d4b614eb516544598b6e661a9d35ad31_TexelSize;
                float4 Texture2D_e9e6a9a58276426799e1092067d4f80d_TexelSize;
                float4 Texture2D_b2322190bca94b94951c18f813f39dce_TexelSize;
                float4 Texture2D_4e2c1d09021f482495c450f712c62ff8_TexelSize;
                float4 Texture2D_79a684fb53ee4feab2ac94b51021af26_TexelSize;
                float Vector1_f76a46c5eed947b3a2a735cc4bdb771a;
                float Vector1_d2a96271474c46c5ab567d69750b0117;
                float Boolean_9b9b8114641e4412b7507f2f263d2633;
                float _Stencil;
                float Vector1_4bfce301afa743508565723be93dc6ed;
                float4 Color_a699c866f1d14065bc7b7abae9858103;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_d4b614eb516544598b6e661a9d35ad31);
                SAMPLER(samplerTexture2D_d4b614eb516544598b6e661a9d35ad31);
                TEXTURE2D(Texture2D_e9e6a9a58276426799e1092067d4f80d);
                SAMPLER(samplerTexture2D_e9e6a9a58276426799e1092067d4f80d);
                TEXTURE2D(Texture2D_b2322190bca94b94951c18f813f39dce);
                SAMPLER(samplerTexture2D_b2322190bca94b94951c18f813f39dce);
                TEXTURE2D(Texture2D_4e2c1d09021f482495c450f712c62ff8);
                SAMPLER(samplerTexture2D_4e2c1d09021f482495c450f712c62ff8);
                TEXTURE2D(Texture2D_79a684fb53ee4feab2ac94b51021af26);
                SAMPLER(samplerTexture2D_79a684fb53ee4feab2ac94b51021af26);
                SAMPLER(_SampleTexture2D_c8191600e030466499f9c87f05567ff9_Sampler_3_Linear_Repeat);
                SAMPLER(_SampleTexture2D_b8a783d302a442c2b687413927ddfde4_Sampler_3_Linear_Repeat);
                SAMPLER(_SampleTexture2D_1444e5380232418fa8460db51070c761_Sampler_3_Linear_Repeat);
    
                // Graph Functions
                
                void Unity_Branch_float4(float Predicate, float4 True, float4 False, out float4 Out)
                {
                    Out = Predicate ? True : False;
                }
                
                void Unity_InvertColors_float4(float4 In, float4 InvertColors, out float4 Out)
                {
                    Out = abs(InvertColors - In);
                }
                
                void Unity_Add_float4(float4 A, float4 B, out float4 Out)
                {
                    Out = A + B;
                }
                
                void Unity_DotProduct_float3(float3 A, float3 B, out float Out)
                {
                    Out = dot(A, B);
                }
                
                void Unity_Subtract_float(float A, float B, out float Out)
                {
                    Out = A - B;
                }
                
                void Unity_Absolute_float(float In, out float Out)
                {
                    Out = abs(In);
                }
                
                void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
                {
                    Out = A * B;
                }
                
                void Unity_Multiply_float(float A, float B, out float Out)
                {
                    Out = A * B;
                }
                
                void Unity_Add_float(float A, float B, out float Out)
                {
                    Out = A + B;
                }
                
                void Unity_Subtract_float4(float4 A, float4 B, out float4 Out)
                {
                    Out = A - B;
                }
    
                // Graph Vertex
                // GraphVertex: <None>
    
                // Graph Pixel
                struct SurfaceDescription
                {
                    float4 Out;
                };
                
                SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
                {
                    SurfaceDescription surface = (SurfaceDescription)0;
                    float _Property_1de086a342fe4d3e8b2271c17c0ebc9e_Out_0 = Boolean_9b9b8114641e4412b7507f2f263d2633;
                    float4 _SampleTexture2D_c8191600e030466499f9c87f05567ff9_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_79a684fb53ee4feab2ac94b51021af26, samplerTexture2D_79a684fb53ee4feab2ac94b51021af26, IN.uv0.xy);
                    float _SampleTexture2D_c8191600e030466499f9c87f05567ff9_R_4 = _SampleTexture2D_c8191600e030466499f9c87f05567ff9_RGBA_0.r;
                    float _SampleTexture2D_c8191600e030466499f9c87f05567ff9_G_5 = _SampleTexture2D_c8191600e030466499f9c87f05567ff9_RGBA_0.g;
                    float _SampleTexture2D_c8191600e030466499f9c87f05567ff9_B_6 = _SampleTexture2D_c8191600e030466499f9c87f05567ff9_RGBA_0.b;
                    float _SampleTexture2D_c8191600e030466499f9c87f05567ff9_A_7 = _SampleTexture2D_c8191600e030466499f9c87f05567ff9_RGBA_0.a;
                    float4 Color_9bcca730a12b44ae8ce1d90812ab1a02 = IsGammaSpace() ? float4(0, 0, 0, 0) : float4(SRGBToLinear(float3(0, 0, 0)), 0);
                    float4 _Branch_fd38e6644bba4ee1b4c47adaf559f266_Out_3;
                    Unity_Branch_float4(_Property_1de086a342fe4d3e8b2271c17c0ebc9e_Out_0, _SampleTexture2D_c8191600e030466499f9c87f05567ff9_RGBA_0, Color_9bcca730a12b44ae8ce1d90812ab1a02, _Branch_fd38e6644bba4ee1b4c47adaf559f266_Out_3);
                    float4 _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_4e2c1d09021f482495c450f712c62ff8, samplerTexture2D_4e2c1d09021f482495c450f712c62ff8, IN.uv0.xy);
                    float _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_R_4 = _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_RGBA_0.r;
                    float _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_G_5 = _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_RGBA_0.g;
                    float _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_B_6 = _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_RGBA_0.b;
                    float _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_A_7 = _SampleTexture2D_b8a783d302a442c2b687413927ddfde4_RGBA_0.a;
                    float4 _InvertColors_c1968f61b43641e68e9e5df40e7ed286_Out_1;
                    float4 _InvertColors_c1968f61b43641e68e9e5df40e7ed286_InvertColors = float4 (1
                , 1, 1, 0);    Unity_InvertColors_float4(_SampleTexture2D_b8a783d302a442c2b687413927ddfde4_RGBA_0, _InvertColors_c1968f61b43641e68e9e5df40e7ed286_InvertColors, _InvertColors_c1968f61b43641e68e9e5df40e7ed286_Out_1);
                    float4 _Add_876b5bf8b491450b8f56f36a67086e92_Out_2;
                    Unity_Add_float4(_Branch_fd38e6644bba4ee1b4c47adaf559f266_Out_3, _InvertColors_c1968f61b43641e68e9e5df40e7ed286_Out_1, _Add_876b5bf8b491450b8f56f36a67086e92_Out_2);
                    float _DotProduct_69e6858fcfe8462dae414a95c18cef5f_Out_2;
                    Unity_DotProduct_float3(IN.WorldSpaceNormal, IN.WorldSpaceTangent, _DotProduct_69e6858fcfe8462dae414a95c18cef5f_Out_2);
                    float _DotProduct_13a786a3fe9545d3894724ef2cd4f111_Out_2;
                    Unity_DotProduct_float3(IN.WorldSpaceViewDirection, IN.WorldSpaceTangent, _DotProduct_13a786a3fe9545d3894724ef2cd4f111_Out_2);
                    float _Subtract_4f73292be3f34b248e942341bc3c5623_Out_2;
                    Unity_Subtract_float(_DotProduct_69e6858fcfe8462dae414a95c18cef5f_Out_2, _DotProduct_13a786a3fe9545d3894724ef2cd4f111_Out_2, _Subtract_4f73292be3f34b248e942341bc3c5623_Out_2);
                    float _Absolute_6e444576ab364fb88b330d4f0b422a94_Out_1;
                    Unity_Absolute_float(_Subtract_4f73292be3f34b248e942341bc3c5623_Out_2, _Absolute_6e444576ab364fb88b330d4f0b422a94_Out_1);
                    float4 _SampleTexture2D_1444e5380232418fa8460db51070c761_RGBA_0 = SAMPLE_TEXTURE2D(Texture2D_e9e6a9a58276426799e1092067d4f80d, samplerTexture2D_e9e6a9a58276426799e1092067d4f80d, (_Absolute_6e444576ab364fb88b330d4f0b422a94_Out_1.xx));
                    float _SampleTexture2D_1444e5380232418fa8460db51070c761_R_4 = _SampleTexture2D_1444e5380232418fa8460db51070c761_RGBA_0.r;
                    float _SampleTexture2D_1444e5380232418fa8460db51070c761_G_5 = _SampleTexture2D_1444e5380232418fa8460db51070c761_RGBA_0.g;
                    float _SampleTexture2D_1444e5380232418fa8460db51070c761_B_6 = _SampleTexture2D_1444e5380232418fa8460db51070c761_RGBA_0.b;
                    float _SampleTexture2D_1444e5380232418fa8460db51070c761_A_7 = _SampleTexture2D_1444e5380232418fa8460db51070c761_RGBA_0.a;
                    float4 _Multiply_33233b85cf064809bb85da70f46efab0_Out_2;
                    Unity_Multiply_float(_Add_876b5bf8b491450b8f56f36a67086e92_Out_2, _SampleTexture2D_1444e5380232418fa8460db51070c761_RGBA_0, _Multiply_33233b85cf064809bb85da70f46efab0_Out_2);
                    float _Property_9f5789d0487840299ee841db9fc4a68a_Out_0 = Vector1_d2a96271474c46c5ab567d69750b0117;
                    float _Multiply_39c0ee3702234b5f9c3beef01cf7bb5c_Out_2;
                    Unity_Multiply_float(_Property_9f5789d0487840299ee841db9fc4a68a_Out_0, 2, _Multiply_39c0ee3702234b5f9c3beef01cf7bb5c_Out_2);
                    float4 _Multiply_8b5bb2b9427f44bc8b5e9f58f13e82bb_Out_2;
                    Unity_Multiply_float(_Multiply_33233b85cf064809bb85da70f46efab0_Out_2, (_Multiply_39c0ee3702234b5f9c3beef01cf7bb5c_Out_2.xxxx), _Multiply_8b5bb2b9427f44bc8b5e9f58f13e82bb_Out_2);
                    float _Property_354cb0b368674f94b0305dbd7ef3d2ee_Out_0 = Vector1_4bfce301afa743508565723be93dc6ed;
                    float _Multiply_13225bfd20ba4ae7a6b9318a6244e097_Out_2;
                    Unity_Multiply_float(_Property_354cb0b368674f94b0305dbd7ef3d2ee_Out_0, -1, _Multiply_13225bfd20ba4ae7a6b9318a6244e097_Out_2);
                    float _Add_0493238bb20b40b789a7ddfe82c89aad_Out_2;
                    Unity_Add_float(_Multiply_13225bfd20ba4ae7a6b9318a6244e097_Out_2, 1, _Add_0493238bb20b40b789a7ddfe82c89aad_Out_2);
                    float _Multiply_c502d5217dae424f86da234e14233057_Out_2;
                    Unity_Multiply_float(_Add_0493238bb20b40b789a7ddfe82c89aad_Out_2, 5, _Multiply_c502d5217dae424f86da234e14233057_Out_2);
                    float4 _Subtract_24aad7c7d462494784ebbe1ceaf95136_Out_2;
                    Unity_Subtract_float4(_Multiply_8b5bb2b9427f44bc8b5e9f58f13e82bb_Out_2, (_Multiply_c502d5217dae424f86da234e14233057_Out_2.xxxx), _Subtract_24aad7c7d462494784ebbe1ceaf95136_Out_2);
                    surface.Out = all(isfinite(_Subtract_24aad7c7d462494784ebbe1ceaf95136_Out_2)) ? half4(_Subtract_24aad7c7d462494784ebbe1ceaf95136_Out_2.x, _Subtract_24aad7c7d462494784ebbe1ceaf95136_Out_2.y, _Subtract_24aad7c7d462494784ebbe1ceaf95136_Out_2.z, 1.0) : float4(1.0f, 0.0f, 1.0f, 1.0f);
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);
                
                	// must use interpolated tangent, bitangent and normal before they are normalized in the pixel shader.
                	float3 unnormalizedNormalWS = input.normalWS;
                    const float renormFactor = 1.0 / length(unnormalizedNormalWS);
                
                
                    output.WorldSpaceNormal =            renormFactor*input.normalWS.xyz;		// we want a unit length Normal Vector node in shader graph
                
                	// to preserve mikktspace compliance we use same scale renormFactor as was used on the normal.
                	// This is explained in section 2.2 in "surface gradient based bump mapping framework"
                    output.WorldSpaceTangent =           renormFactor*input.tangentWS.xyz;
                
                    output.WorldSpaceViewDirection =     input.viewDirectionWS; //TODO: by default normalized in HD, but not in universal
                    output.uv0 =                         input.texCoord0;
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
                #else
                #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
                #endif
                #undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
                
                    return output;
                }
                
    
                // --------------------------------------------------
                // Main
    
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/PreviewVaryings.hlsl"
                #include "Packages/com.unity.shadergraph/ShaderGraphLibrary/PreviewPass.hlsl"
    
                ENDHLSL
            }
        }
        FallBack "Hidden/Shader Graph/FallbackError"
    }
