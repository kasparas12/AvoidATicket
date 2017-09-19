package mono.com.google.android.exoplayer2.trackselection;


public class TrackSelector_EventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.trackselection.TrackSelector.EventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTrackSelectionsChanged:(Lcom/google/android/exoplayer2/trackselection/TrackSelections;)V:GetOnTrackSelectionsChanged_Lcom_google_android_exoplayer2_trackselection_TrackSelections_Handler:Com.Google.Android.Exoplayer2.Trackselection.TrackSelector/IEventListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Trackselection.TrackSelector+IEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TrackSelector_EventListenerImplementor.class, __md_methods);
	}


	public TrackSelector_EventListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TrackSelector_EventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Trackselection.TrackSelector+IEventListenerImplementor, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onTrackSelectionsChanged (com.google.android.exoplayer2.trackselection.TrackSelections p0)
	{
		n_onTrackSelectionsChanged (p0);
	}

	private native void n_onTrackSelectionsChanged (com.google.android.exoplayer2.trackselection.TrackSelections p0);

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
