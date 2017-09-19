package mono.com.google.android.exoplayer2;


public class SimpleExoPlayer_VideoListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.SimpleExoPlayer.VideoListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRenderedFirstFrame:()V:GetInvokeOnRenderedFirstFrameHandler:Com.Google.Android.Exoplayer2.SimpleExoPlayer/IVideoListenerInvoker, ExoPlayer\n" +
			"n_onVideoSizeChanged:(IIIF)V:GetInvokeOnVideoSizeChanged_IIIFHandler:Com.Google.Android.Exoplayer2.SimpleExoPlayer/IVideoListenerInvoker, ExoPlayer\n" +
			"n_onVideoTracksDisabled:()V:GetOnVideoTracksDisabledHandler:Com.Google.Android.Exoplayer2.SimpleExoPlayer/IVideoListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.SimpleExoPlayer+IVideoListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SimpleExoPlayer_VideoListenerImplementor.class, __md_methods);
	}


	public SimpleExoPlayer_VideoListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SimpleExoPlayer_VideoListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.SimpleExoPlayer+IVideoListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onRenderedFirstFrame ()
	{
		n_onRenderedFirstFrame ();
	}

	private native void n_onRenderedFirstFrame ();


	public void onVideoSizeChanged (int p0, int p1, int p2, float p3)
	{
		n_onVideoSizeChanged (p0, p1, p2, p3);
	}

	private native void n_onVideoSizeChanged (int p0, int p1, int p2, float p3);


	public void onVideoTracksDisabled ()
	{
		n_onVideoTracksDisabled ();
	}

	private native void n_onVideoTracksDisabled ();

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
