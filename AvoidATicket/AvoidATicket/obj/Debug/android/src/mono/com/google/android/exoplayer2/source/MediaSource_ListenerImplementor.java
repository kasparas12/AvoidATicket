package mono.com.google.android.exoplayer2.source;


public class MediaSource_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.source.MediaSource.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSourceInfoRefreshed:(Lcom/google/android/exoplayer2/Timeline;Ljava/lang/Object;)V:GetOnSourceInfoRefreshed_Lcom_google_android_exoplayer2_Timeline_Ljava_lang_Object_Handler:Com.Google.Android.Exoplayer2.Source.IMediaSourceListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Source.IMediaSourceListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MediaSource_ListenerImplementor.class, __md_methods);
	}


	public MediaSource_ListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MediaSource_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Source.IMediaSourceListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onSourceInfoRefreshed (com.google.android.exoplayer2.Timeline p0, java.lang.Object p1)
	{
		n_onSourceInfoRefreshed (p0, p1);
	}

	private native void n_onSourceInfoRefreshed (com.google.android.exoplayer2.Timeline p0, java.lang.Object p1);

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
