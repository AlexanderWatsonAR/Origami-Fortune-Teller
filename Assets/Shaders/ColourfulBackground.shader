Shader "ColourfulBackground"
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
            _MainTex("Base (RGB)", 2D) = "white" {}

            Vector1_f44ef88e413048ce8485c560dff82432("Temperature", Range(-5, 5)) = -0.3
            [NoScaleOffset]Texture2D_42e876978b284ba58f08517eafefef4f("MainTex", 2D) = "white" {}
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
                #define ATTRIBUTES_NEED_TEXCOORD0
                #define VARYINGS_NEED_TEXCOORD0
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
                    float4 uv0 : TEXCOORD0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : INSTANCEID_SEMANTIC;
                    #endif
                };
                struct Varyings
                {
                    float4 positionCS : SV_POSITION;
                    float4 texCoord0;
                    #if UNITY_ANY_INSTANCING_ENABLED
                    uint instanceID : CUSTOM_INSTANCE_ID;
                    #endif
                    #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                    FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
                    #endif
                };
                struct SurfaceDescriptionInputs
                {
                    float4 uv0;
                    float3 TimeParameters;
                };
                struct VertexDescriptionInputs
                {
                };
                struct PackedVaryings
                {
                    float4 positionCS : SV_POSITION;
                    float4 interp0 : TEXCOORD0;
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
                    output.interp0.xyzw =  input.texCoord0;
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
                    output.texCoord0 = input.interp0.xyzw;
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
                float Vector1_f44ef88e413048ce8485c560dff82432;
                float4 Texture2D_42e876978b284ba58f08517eafefef4f_TexelSize;
                CBUFFER_END
                
                // Object and Global properties
                TEXTURE2D(Texture2D_42e876978b284ba58f08517eafefef4f);
                SAMPLER(samplerTexture2D_42e876978b284ba58f08517eafefef4f);
    
                // Graph Functions
                
                void Unity_Multiply_float(float A, float B, out float Out)
                {
                    Out = A * B;
                }
                
                void Unity_Rotate_Radians_float(float2 UV, float2 Center, float Rotation, out float2 Out)
                {
                    //rotation matrix
                    UV -= Center;
                    float s = sin(Rotation);
                    float c = cos(Rotation);
                
                    //center rotation matrix
                    float2x2 rMatrix = float2x2(c, -s, s, c);
                    rMatrix *= 0.5;
                    rMatrix += 0.5;
                    rMatrix = rMatrix*2 - 1;
                
                    //multiply the UVs by the rotation matrix
                    UV.xy = mul(UV.xy, rMatrix);
                    UV += Center;
                
                    Out = UV;
                }
                
                void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
                {
                    Out = UV * Tiling + Offset;
                }
                
                
                float2 Unity_GradientNoise_Dir_float(float2 p)
                {
                    // Permutation and hashing used in webgl-nosie goo.gl/pX7HtC
                    p = p % 289;
                    // need full precision, otherwise half overflows when p > 1
                    float x = float(34 * p.x + 1) * p.x % 289 + p.y;
                    x = (34 * x + 1) * x % 289;
                    x = frac(x / 41) * 2 - 1;
                    return normalize(float2(x - floor(x + 0.5), abs(x) - 0.5));
                }
                
                void Unity_GradientNoise_float(float2 UV, float Scale, out float Out)
                { 
                    float2 p = UV * Scale;
                    float2 ip = floor(p);
                    float2 fp = frac(p);
                    float d00 = dot(Unity_GradientNoise_Dir_float(ip), fp);
                    float d01 = dot(Unity_GradientNoise_Dir_float(ip + float2(0, 1)), fp - float2(0, 1));
                    float d10 = dot(Unity_GradientNoise_Dir_float(ip + float2(1, 0)), fp - float2(1, 0));
                    float d11 = dot(Unity_GradientNoise_Dir_float(ip + float2(1, 1)), fp - float2(1, 1));
                    fp = fp * fp * fp * (fp * (fp * 6 - 15) + 10);
                    Out = lerp(lerp(d00, d01, fp.y), lerp(d10, d11, fp.y), fp.x) + 0.5;
                }
                
                void Unity_Spherize_float(float2 UV, float2 Center, float2 Strength, float2 Offset, out float2 Out)
                {
                    float2 delta = UV - Center;
                    float delta2 = dot(delta.xy, delta.xy);
                    float delta4 = delta2 * delta2;
                    float2 delta_offset = delta4 * Strength;
                    Out = UV + delta * delta_offset + Offset;
                }
                
                void Unity_Contrast_float(float3 In, float Contrast, out float3 Out)
                {
                    float midpoint = pow(0.5, 2.2);
                    Out =  (In - midpoint) * Contrast + midpoint;
                }
                
                void Unity_Blend_Overlay_float3(float3 Base, float3 Blend, out float3 Out, float Opacity)
                {
                    float3 result1 = 1.0 - 2.0 * (1.0 - Base) * (1.0 - Blend);
                    float3 result2 = 2.0 * Base * Blend;
                    float3 zeroOrOne = step(Base, 0.5);
                    Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
                    Out = lerp(Base, Out, Opacity);
                }
                
                void Unity_WhiteBalance_float(float3 In, float Temperature, float Tint, out float3 Out)
                {
                    // Range ~[-1.67;1.67] works best
                    float t1 = Temperature * 10 / 6;
                    float t2 = Tint * 10 / 6;

                    // Get the CIE xy chromaticity of the reference white point.
                    // Note: 0.31271 = x value on the D65 white point
                    float x = 0.31271 - t1 * (t1 < 0 ? 0.1 : 0.05);
                    float standardIlluminantY = 2.87 * x - 3 * x * x - 0.27509507;
                    float y = standardIlluminantY + t2 * 0.05;

                    // Calculate the coefficients in the LMS space.
                    float3 w1 = float3(0.949237, 1.03542, 1.08728); // D65 white point

                    // CIExyToLMS
                    float Y = 1;
                    float X = Y * x / y;
                    float Z = Y * (1 - x - y) / y;
                    float L = 0.7328 * X + 0.4296 * Y - 0.1624 * Z;
                    float M = -0.7036 * X + 1.6975 * Y + 0.0061 * Z;
                    float S = 0.0030 * X + 0.0136 * Y + 0.9834 * Z;
                    float3 w2 = float3(L, M, S);

                    float3 balance = float3(w1.x / w2.x, w1.y / w2.y, w1.z / w2.z);

                    float3x3 LIN_2_LMS_MAT = {
                    3.90405e-1, 5.49941e-1, 8.92632e-3,
                    7.08416e-2, 9.63172e-1, 1.35775e-3,
                    2.31082e-2, 1.28021e-1, 9.36245e-1
                    };

                    float3x3 LMS_2_LIN_MAT = {
                    2.85847e+0, -1.62879e+0, -2.48910e-2,
                    -2.10182e-1,  1.15820e+0,  3.24281e-4,
                    -4.18120e-2, -1.18169e-1,  1.06867e+0
                    };

                    float3 lms = mul(LIN_2_LMS_MAT, In);
                    lms *= balance;
                    Out = mul(LMS_2_LIN_MAT, lms);
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
                    float _Multiply_e692b924fdd34c83b1a7a909541d0d34_Out_2;
                    Unity_Multiply_float(IN.TimeParameters.x, 0.1, _Multiply_e692b924fdd34c83b1a7a909541d0d34_Out_2);
                    float2 _Rotate_a5d0f4f4493f4312a0e27a12b0576d67_Out_3;
                    Unity_Rotate_Radians_float(IN.uv0.xy, float2 (0.5, 0.5), _Multiply_e692b924fdd34c83b1a7a909541d0d34_Out_2, _Rotate_a5d0f4f4493f4312a0e27a12b0576d67_Out_3);
                    float2 _TilingAndOffset_f681cef6d95948839699a95fa850960b_Out_3;
                    Unity_TilingAndOffset_float(IN.uv0.xy, float2 (1, 0), float2 (-3.14, -0.3), _TilingAndOffset_f681cef6d95948839699a95fa850960b_Out_3);
                    float _GradientNoise_4b43b993afca46e1bf5dc9244948c7bc_Out_2;
                    Unity_GradientNoise_float(_TilingAndOffset_f681cef6d95948839699a95fa850960b_Out_3, 0.16, _GradientNoise_4b43b993afca46e1bf5dc9244948c7bc_Out_2);
                    float2 _Spherize_4c51c17019cc41d1afd291b000ccf09f_Out_4;
                    Unity_Spherize_float(_Rotate_a5d0f4f4493f4312a0e27a12b0576d67_Out_3, (_GradientNoise_4b43b993afca46e1bf5dc9244948c7bc_Out_2.xx), float2 (10, 10), float2 (0, 0), _Spherize_4c51c17019cc41d1afd291b000ccf09f_Out_4);
                    float3 _Contrast_efd136b1073e4ce6a3698aa4a9c36ee6_Out_2;
                    Unity_Contrast_float((float3(_Spherize_4c51c17019cc41d1afd291b000ccf09f_Out_4, 0.0)), -0.3, _Contrast_efd136b1073e4ce6a3698aa4a9c36ee6_Out_2);
                    float3 _Blend_0d3534677d3647f4b1ac1a071bf33adf_Out_2;
                    Unity_Blend_Overlay_float3(_Contrast_efd136b1073e4ce6a3698aa4a9c36ee6_Out_2, float3(1, 1, 1), _Blend_0d3534677d3647f4b1ac1a071bf33adf_Out_2, 1);
                    float _Property_fc741c58050a4e098b20aee892d7c11c_Out_0 = Vector1_f44ef88e413048ce8485c560dff82432;
                    float3 _WhiteBalance_379c80997f4346038db31c5100997cd0_Out_3;
                    Unity_WhiteBalance_float(_Blend_0d3534677d3647f4b1ac1a071bf33adf_Out_2, _Property_fc741c58050a4e098b20aee892d7c11c_Out_0, 1.14, _WhiteBalance_379c80997f4346038db31c5100997cd0_Out_3);
                    surface.Out = all(isfinite(_WhiteBalance_379c80997f4346038db31c5100997cd0_Out_3)) ? half4(_WhiteBalance_379c80997f4346038db31c5100997cd0_Out_3.x, _WhiteBalance_379c80997f4346038db31c5100997cd0_Out_3.y, _WhiteBalance_379c80997f4346038db31c5100997cd0_Out_3.z, 1.0) : float4(1.0f, 0.0f, 1.0f, 1.0f);
                    return surface;
                }
    
                // --------------------------------------------------
                // Build Graph Inputs
    
                SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
                {
                    SurfaceDescriptionInputs output;
                    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);

                    output.uv0 = input.texCoord0;
                    output.TimeParameters = _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
                #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
                #define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign = IS_FRONT_VFACE(input.cullFace, true, false);
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
