package md523f63e2aa4c69b9e618683451e9b006b;


public class AppCompatAnimationNavRenderer
	extends md58432a647068b097f9637064b8985a5e0.NavigationPageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FormsControls.Droid.AppCompatAnimationNavRenderer, FormsControls.Droid", AppCompatAnimationNavRenderer.class, __md_methods);
	}


	public AppCompatAnimationNavRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == AppCompatAnimationNavRenderer.class)
			mono.android.TypeManager.Activate ("FormsControls.Droid.AppCompatAnimationNavRenderer, FormsControls.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public AppCompatAnimationNavRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == AppCompatAnimationNavRenderer.class)
			mono.android.TypeManager.Activate ("FormsControls.Droid.AppCompatAnimationNavRenderer, FormsControls.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public AppCompatAnimationNavRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AppCompatAnimationNavRenderer.class)
			mono.android.TypeManager.Activate ("FormsControls.Droid.AppCompatAnimationNavRenderer, FormsControls.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
