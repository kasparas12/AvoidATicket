package md53ce4ea341869b8b1661b93bcbf6e6e9a;


public class TrackSelections
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Trackselection.TrackSelections, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TrackSelections.class, __md_methods);
	}


	public TrackSelections () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TrackSelections.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Trackselection.TrackSelections, ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
