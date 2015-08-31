using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class StopwatchWrap
{
	Stopwatch m_stopwatch = new Stopwatch();

	bool m_bStart = false;
	public double m_second  = 0;
	public void Start () 
	{
		m_stopwatch.Start(); 
		m_bStart = true; 
	}
 
	//return second
	public double Stop () 
	{
		if(!m_bStart)
			return 0;

		m_stopwatch.Stop(); 
		return (double)m_stopwatch.ElapsedTicks/(double)Stopwatch.Frequency;
	}
 
	public double Second 
	{
		get
		{
			if(!m_bStart)
				return 0;
			return (double)m_stopwatch.ElapsedTicks/(double)Stopwatch.Frequency; 
		}

	}

	public string ToStringFrame 
	{
		get
		{
			double perSec = 0;
			if(Second != 0)
			{
				perSec = (double)1/Second;
			} 
			return string.Format("{0} Frame", perSec);
		}
	}
}
