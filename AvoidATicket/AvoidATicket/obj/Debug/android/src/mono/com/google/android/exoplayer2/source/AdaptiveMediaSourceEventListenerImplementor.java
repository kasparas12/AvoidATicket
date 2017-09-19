package mono.com.google.android.exoplayer2.source;


public class AdaptiveMediaSourceEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.source.AdaptiveMediaSourceEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDownstreamFormatChanged:(ILcom/google/android/exoplayer2/Format;ILjava/lang/Object;J)V:GetOnDownstreamFormatChanged_ILcom_google_android_exoplayer2_Format_ILjava_lang_Object_JHandler:Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerInvoker, ExoPlayer\n" +
			"n_onLoadCanceled:(Lcom/google/android/exoplayer2/upstream/DataSpec;IILcom/google/android/exoplayer2/Format;ILjava/lang/Object;JJJJJ)V:GetOnLoadCanceled_Lcom_google_android_exoplayer2_upstream_DataSpec_IILcom_google_android_exoplayer2_Format_ILjava_lang_Object_JJJJJHandler:Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerInvoker, ExoPlayer\n" +
			"n_onLoadCompleted:(Lcom/google/android/exoplayer2/upstream/DataSpec;IILcom/google/android/exoplayer2/Format;ILjava/lang/Object;JJJJJ)V:GetOnLoadCompleted_Lcom_google_android_exoplayer2_upstream_DataSpec_IILcom_google_android_exoplayer2_Format_ILjava_lang_Object_JJJJJHandler:Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerInvoker, ExoPlayer\n" +
			"n_onLoadError:(Lcom/google/android/exoplayer2/upstream/DataSpec;IILcom/google/android/exoplayer2/Format;ILjava/lang/Object;JJJJJLjava/io/IOException;Z)V:GetOnLoadError_Lcom_google_android_exoplayer2_upstream_DataSpec_IILcom_google_android_exoplayer2_Format_ILjava_lang_Object_JJJJJLjava_io_IOException_ZHandler:Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerInvoker, ExoPlayer\n" +
			"n_onLoadStarted:(Lcom/google/android/exoplayer2/upstream/DataSpec;IILcom/google/android/exoplayer2/Format;ILjava/lang/Object;JJJ)V:GetOnLoadStarted_Lcom_google_android_exoplayer2_upstream_DataSpec_IILcom_google_android_exoplayer2_Format_ILjava_lang_Object_JJJHandler:Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerInvoker, ExoPlayer\n" +
			"n_onUpstreamDiscarded:(IJJ)V:GetOnUpstreamDiscarded_IJJHandler:Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AdaptiveMediaSourceEventListenerImplementor.class, __md_methods);
	}


	public AdaptiveMediaSourceEventListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AdaptiveMediaSourceEventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Source.IAdaptiveMediaSourceEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onDownstreamFormatChanged (int p0, com.google.android.exoplayer2.Format p1, int p2, java.lang.Object p3, long p4)
	{
		n_onDownstreamFormatChanged (p0, p1, p2, p3, p4);
	}

	private native void n_onDownstreamFormatChanged (int p0, com.google.android.exoplayer2.Format p1, int p2, java.lang.Object p3, long p4);


	public void onLoadCanceled (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8, long p9, long p10)
	{
		n_onLoadCanceled (p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	private native void n_onLoadCanceled (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8, long p9, long p10);


	public void onLoadCompleted (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8, long p9, long p10)
	{
		n_onLoadCompleted (p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
	}

	private native void n_onLoadCompleted (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8, long p9, long p10);


	public void onLoadError (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8, long p9, long p10, java.io.IOException p11, boolean p12)
	{
		n_onLoadError (p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
	}

	private native void n_onLoadError (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8, long p9, long p10, java.io.IOException p11, boolean p12);


	public void onLoadStarted (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8)
	{
		n_onLoadStarted (p0, p1, p2, p3, p4, p5, p6, p7, p8);
	}

	private native void n_onLoadStarted (com.google.android.exoplayer2.upstream.DataSpec p0, int p1, int p2, com.google.android.exoplayer2.Format p3, int p4, java.lang.Object p5, long p6, long p7, long p8);


	public void onUpstreamDiscarded (int p0, long p1, long p2)
	{
		n_onUpstreamDiscarded (p0, p1, p2);
	}

	private native void n_onUpstreamDiscarded (int p0, long p1, long p2);

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
