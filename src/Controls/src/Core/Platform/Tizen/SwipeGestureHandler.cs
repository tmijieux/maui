﻿using ElmSharp;

namespace Microsoft.Maui.Controls.Platform
{
	public class SwipeGestureHandler : GestureHandler
	{
		public SwipeGestureHandler(IGestureRecognizer recognizer) : base(recognizer)
		{
		}

		public override GestureLayer.GestureType Type => GestureLayer.GestureType.Flick;

		protected override void OnStarted(View sender, object data) { }

		protected override void OnMoved(View sender, object data) { }

		protected override void OnCompleted(View sender, object data)
		{
			if (Recognizer is SwipeGestureRecognizer swipeGesture)
			{
				var lineData = (GestureLayer.LineData)data;
				(swipeGesture as ISwipeGestureController)?.SendSwipe(sender, DPExtensions.ConvertToScaledDP(lineData.X2 - lineData.X1), DPExtensions.ConvertToScaledDP(lineData.Y2 - lineData.Y1));
				(swipeGesture as ISwipeGestureController)?.DetectSwipe(sender, swipeGesture.Direction);
			}
		}

		protected override void OnCanceled(View sender, object data) { }
	}
}