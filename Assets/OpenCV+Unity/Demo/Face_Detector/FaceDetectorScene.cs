namespace OpenCvSharp.Demo
{
	using UnityEngine;
	using OpenCvSharp;

	public class FaceDetectorScene : WebCamera
	{
		public TextAsset faces;
		public TextAsset eyes;
		public TextAsset shapes;

		public Texture2D faceTexture { get; private set; } = null;

		private FaceProcessorLive<WebCamTexture> processor;

		protected override void OnEnable()
		{
			base.OnEnable();
			base.forceFrontalCamera = true;

			processor = new FaceProcessorLive<WebCamTexture>();
			processor.Initialize(faces.text, eyes.text, shapes.bytes);

			processor.DataStabilizer.Enabled = true;  
			processor.DataStabilizer.Threshold = 2.0; 
			processor.DataStabilizer.SamplesCount = 2; 

			processor.Performance.Downscale = 256; 
			processor.Performance.SkipRate = 0; 
		}

		protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
		{
			processor.ProcessTexture(input, TextureParameters);
			processor.MarkDetected();

			Texture2D input2D = new Texture2D(input.width, input.height);
			input2D.SetPixels(input.GetPixels());
			input2D.Apply();

			if (processor.Faces.Count == 0)
			{
				if (faceTexture != null)
					output = faceTexture;
				else
				{
					output = input2D;
				}
				return true;
			}

			Point topRight = processor.Faces[0].Region.TopRight;
			Point bottomLeft = processor.Faces[0].Region.BottomLeft;
			
			if (topRight.X <= 0 || topRight.Y <= 0 || bottomLeft.X <= 0 || bottomLeft.Y <= 0)
			{
				if (faceTexture != null)
					output = faceTexture;
				else
				{
					output = input2D;
				}
				return true;
			}
			faceTexture = TrimmingTexture.Trim(new Vector2Int(topRight.X, topRight.Y), new Vector2Int(bottomLeft.X, bottomLeft.Y), input2D);
			return true;
		}

		public void ResetFaceTex()
        {
			faceTexture = null;
		}
    }
}