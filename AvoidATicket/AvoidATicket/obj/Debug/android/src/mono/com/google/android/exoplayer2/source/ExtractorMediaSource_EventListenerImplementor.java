package mono.com.google.android.exoplayer2.source;


public class ExtractorMediaSource_EventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.source.ExtractorMediaSource.EventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLoadError:(Ljava/io/IOException;)V:GetOnLoadError_Ljava_io_IOException_Handler:Com.Google.Android.Exoplayer2.Source.ExtractorMediaSource/IEventListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Source.ExtractorMediaSource+IEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ExtractorMediaSource_EventListenerImplementor.class, __md_methods);
	}


	public ExtractorMediaSource_EventListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ExtractorMediaSource_EventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Source.ExtractorMediaSource+IEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onLoadError (java.io.IOException p0)
	{
		n_onLoadError (p0);
	}

	private native void n_onLoadError (java.io.IOException p0);

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
