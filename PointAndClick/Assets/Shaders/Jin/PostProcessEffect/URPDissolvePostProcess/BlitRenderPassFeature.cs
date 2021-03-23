using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace COMP1288.PointClick.Jin
{
    public class BlitRenderPassFeature : ScriptableRendererFeature
    {
        class CustomRenderPass : ScriptableRenderPass
        {
            public RenderTargetIdentifier SourceID;
            private Material mat;
            private int materialPassIndex;
            private RenderTargetHandle tempRenderTargetHandler;

            //constructor to recieve material
            public CustomRenderPass(Material mat, int passIndex, RenderPassEvent renderPass)
            {
                this.mat = mat;
                this.materialPassIndex = passIndex;
                tempRenderTargetHandler.Init("_TemporaryColorTexture");
            }

            public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
            {
            }

            public void SetSource(RenderTargetIdentifier source)
            {
                this.SourceID = source;
            }

            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                CommandBuffer cmd = CommandBufferPool.Get();
                cmd.GetTemporaryRT(tempRenderTargetHandler.id, renderingData.cameraData.cameraTargetDescriptor);

                //copy from source onto temp render texture to apply material
                Blit(cmd, SourceID, tempRenderTargetHandler.Identifier(), mat, materialPassIndex);
                //copy from temp texture onto source
                Blit(cmd, tempRenderTargetHandler.Identifier(), SourceID);


                //execute command buffer
                context.ExecuteCommandBuffer(cmd);
                //release it from pool
                CommandBufferPool.Release(cmd);
            }

            /// Cleanup any allocated resources that were created during the execution of this render pass.
            public override void FrameCleanup(CommandBuffer cmd)
            {
            }
        }

        [System.Serializable]
        public class Settings
        {
            public Material material;
            public int materialPassIndex = -1;
            public RenderPassEvent renderPass = RenderPassEvent.AfterRenderingOpaques;
        }

        [SerializeField]
        public Settings settings = new Settings();

        CustomRenderPass m_ScriptablePass;

        public Material Material
        {
            get => settings.material;
        }

        public override void Create()
        {
            m_ScriptablePass = new CustomRenderPass(settings.material, settings.materialPassIndex, settings.renderPass);

            // Configures where the render pass should be injected.
            m_ScriptablePass.renderPassEvent = settings.renderPass; // had it before post processing
        }

        // Here you can inject one or multiple render passes in the renderer.
        // This method is called when setting up the renderer once per-camera.
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            m_ScriptablePass.SourceID = renderer.cameraColorTarget;

            renderer.EnqueuePass(m_ScriptablePass);
        }
    }
}

