using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Util;
using DLToolkit.Forms.Controls;
using DLToolkitControlsSamples.Droid;

[assembly: ExportRenderer(typeof(Entry), typeof(TagEntryRenderer))]
namespace DLToolkitControlsSamples.Droid
{
	[Activity(Label = "DLToolkitControlsSamples.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			CachedImageRenderer.Init();
			TagEntryRenderer.Init();
			LoadApplication(new App());
		}
	}

	// https://github.com/daniel-luberda/DLToolkit.Forms.Controls/issues/78
	public class TagEntryRenderer : EntryRenderer
	{
		public static void Init()
		{
			new TagEntryRenderer();
		}

		public TagEntryRenderer()
		{
		}

		public TagEntryRenderer(Context context) : base()
		{
		}

		public TagEntryRenderer(Context context, IAttributeSet attrs) : base()
		{
		}

		public TagEntryRenderer(Context context, IAttributeSet attrs, int defStyle) : base()
		{
		}
		public TagEntryRenderer(IntPtr a, JniHandleOwnership b) : base()
		{
		}
	}

}
