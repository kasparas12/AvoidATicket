package mono.com.google.android.exoplayer2;


public class ExoPlayer_EventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.ExoPlayer.EventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLoadingChanged:(Z)V:GetOnLoadingChanged_ZHandler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onPlayerError:(Lcom/google/android/exoplayer2/ExoPlaybackException;)V:GetOnPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_Handler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onPlayerStateChanged:(ZI)V:GetOnPlayerStateChanged_ZIHandler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onPositionDiscontinuity:()V:GetOnPositionDiscontinuityHandler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onTimelineChanged:(Lcom/google/android/exoplayer2/Timeline;Ljava/lang/Object;)V:GetOnTimelineChanged_Lcom_google_android_exoplayer2_Timeline_Ljava_lang_Object_Handler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.IExoPlayerEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ExoPlayer_EventListenerImplementor.class, __md_methods);
	}


	public ExoPlayer_EventListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ExoPlayer_EventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.IExoPlayerEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onLoadingChanged (boolean p0)
	{
		n_onLoadingChanged (p0);
	}

	private native void n_onLoadingChanged (boolean p0);


	public void onPlayerError (com.google.android.exoplayer2.ExoPlaybackException p0)
	{
		n_onPlayerError (p0);
	}

	private native void n_onPlayerError (com.google.android.exoplayer2.ExoPlaybackException p0);


	public void onPlayerStateChanged (boolean p0, int p1)
	{
		n_onPlayerStateChanged (p0, p1);
	}

	private native void n_onPlayerStateChanged (boolean p0, int p1);


	public void onPositionDiscontinuity ()
	{
		n_onPositionDiscontinuity ();
	}

	private native void n_onPositionDiscontinuity ();


	public void onTimelineChanged (com.google.android.exoplayer2.Timeline p0, java.lang.Object p1)
	{
		n_onTimelineChanged (p0, p1);
	}

	private native void n_onTimelineChanged (com.google.android.exoplayer2.Timeline p0, java.lang.Object p1);

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
