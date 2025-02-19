using System;
using ObjCRuntime;
using UIKit;

namespace Microsoft.Maui.Handlers
{
	public partial class SliderHandler : ViewHandler<ISlider, UISlider>
	{
		protected override UISlider CreatePlatformView() => new UISlider { Continuous = true };

		protected override void ConnectHandler(UISlider platformView)
		{
			base.ConnectHandler(platformView);

			platformView.ValueChanged += OnControlValueChanged;
			platformView.AddTarget(OnTouchDownControlEvent, UIControlEvent.TouchDown);
			platformView.AddTarget(OnTouchUpControlEvent, UIControlEvent.TouchUpInside | UIControlEvent.TouchUpOutside);
		}

		protected override void DisconnectHandler(UISlider platformView)
		{
			base.DisconnectHandler(platformView);

			platformView.ValueChanged -= OnControlValueChanged;
			platformView.RemoveTarget(OnTouchDownControlEvent, UIControlEvent.TouchDown);
			platformView.RemoveTarget(OnTouchUpControlEvent, UIControlEvent.TouchUpInside | UIControlEvent.TouchUpOutside);
		}

		public static void MapMinimum(ISliderHandler handler, ISlider slider)
		{
			handler.PlatformView?.UpdateMinimum(slider);
		}

		public static void MapMaximum(ISliderHandler handler, ISlider slider)
		{
			handler.PlatformView?.UpdateMaximum(slider);
		}

		public static void MapValue(ISliderHandler handler, ISlider slider)
		{
			handler.PlatformView?.UpdateValue(slider);
		}

		public static void MapMinimumTrackColor(ISliderHandler handler, ISlider slider)
		{
			handler.PlatformView?.UpdateMinimumTrackColor(slider);
		}

		public static void MapMaximumTrackColor(ISliderHandler handler, ISlider slider)
		{
			handler.PlatformView?.UpdateMaximumTrackColor(slider);
		}

		public static void MapThumbColor(ISliderHandler handler, ISlider slider)
		{
			handler.PlatformView?.UpdateThumbColor(slider);
		}

		public static void MapThumbImageSource(ISliderHandler handler, ISlider slider)
		{
			var provider = handler.GetRequiredService<IImageSourceServiceProvider>();

			handler.PlatformView?.UpdateThumbImageSourceAsync(slider, provider)
				.FireAndForget(handler);
		}

		void OnControlValueChanged(object? sender, EventArgs eventArgs)
		{
			if (PlatformView == null || VirtualView == null)
				return;

			VirtualView.Value = PlatformView.Value;
		}

		void OnTouchDownControlEvent(object? sender, EventArgs e)
		{
			VirtualView?.DragStarted();
		}

		void OnTouchUpControlEvent(object? sender, EventArgs e)
		{
			VirtualView?.DragCompleted();
		}
	}
}