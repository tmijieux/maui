﻿#if __IOS__ || MACCATALYST
using PlatformView = UIKit.UIMenuElement;
#elif MONOANDROID
using PlatformView = Android.Views.View;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.MenuFlyoutItem;
#elif TIZEN
using PlatformView = ElmSharp.EvasObject;
#elif NETSTANDARD || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Handlers
{
	public interface IMenuFlyoutItemHandler : IElementHandler
	{
		new IMenuFlyoutItem VirtualView { get; }
		new PlatformView PlatformView { get; }
	}
}
