package mono.com.google.android.exoplayer2.extractor;


public class DefaultTrackOutput_UpstreamFormatChangedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.extractor.DefaultTrackOutput.UpstreamFormatChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onUpstreamFormatChanged:(Lcom/google/android/exoplayer2/Format;)V:GetOnUpstreamFormatChanged_Lcom_google_android_exoplayer2_Format_Handler:Com.Google.Android.Exoplayer2.Extractor.DefaultTrackOutput/IUpstreamFormatChangedListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Extractor.DefaultTrackOutput+IUpstreamFormatChangedListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DefaultTrackOutput_UpstreamFormatChangedListenerImplementor.class, __md_methods);
	}


	public DefaultTrackOutput_UpstreamFormatChangedListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DefaultTrackOutput_UpstreamFormatChangedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Extractor.DefaultTrackOutput+IUpstreamFormatChangedListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onUpstreamFormatChanged (com.google.android.exoplayer2.Format p0)
	{
		n_onUpstreamFormatChanged (p0);
	}

	private native void n_onUpstreamFormatChanged (com.google.android.exoplayer2.Format p0);

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
