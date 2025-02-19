﻿#if __IOS__ || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiShapeView;
#elif MONOANDROID
using PlatformView = Microsoft.Maui.Platform.MauiShapeView;
#elif WINDOWS
using PlatformView = Microsoft.Maui.Graphics.Win2D.W2DGraphicsView;
#elif TIZEN
using PlatformView = Microsoft.Maui.Platform.MauiShapeView;
#elif NETSTANDARD || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif


namespace Microsoft.Maui.Handlers
{
	public partial class ShapeViewHandler : IShapeViewHandler
	{
		public static IPropertyMapper<IShapeView, IShapeViewHandler> Mapper = new PropertyMapper<IShapeView, IShapeViewHandler>(ViewHandler.ViewMapper)
		{
			[nameof(IShapeView.Background)] = MapBackground,
			[nameof(IShapeView.Shape)] = MapShape,
			[nameof(IShapeView.Aspect)] = MapAspect,
			[nameof(IShapeView.Fill)] = MapFill,
			[nameof(IShapeView.Stroke)] = MapStroke,
			[nameof(IShapeView.StrokeThickness)] = MapStrokeThickness,
			[nameof(IShapeView.StrokeDashPattern)] = MapStrokeDashPattern,
			[nameof(IShapeView.StrokeDashOffset)] = MapStrokeDashOffset,
			[nameof(IShapeView.StrokeLineCap)] = MapStrokeLineCap,
			[nameof(IShapeView.StrokeLineJoin)] = MapStrokeLineJoin,
			[nameof(IShapeView.StrokeMiterLimit)] = MapStrokeMiterLimit
		};

		public static CommandMapper<IShapeView, IShapeViewHandler> CommandMapper = new(ViewCommandMapper)
		{
		};

		public ShapeViewHandler() : base(Mapper)
		{
		}

		public ShapeViewHandler(IPropertyMapper mapper) : base(mapper ?? Mapper)
		{
		}

		IShapeView IShapeViewHandler.VirtualView => VirtualView;

		PlatformView IShapeViewHandler.PlatformView => PlatformView;
	}
}