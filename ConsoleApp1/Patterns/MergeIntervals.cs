using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgos.Patterns
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }


        public static List<Interval> InsertInterval(List<Interval> intervals, Interval newInterval)
        {
            if (intervals == null || intervals.Count <= 0)
                return new List<Interval>() { new Interval(newInterval.Start, newInterval.End) };

            var mergedInterval = new List<Interval>();
            // sort the intervals by start time
            int i = 0;
            while (i < intervals.Count && intervals[i].End < newInterval.Start)
            {
                mergedInterval.Add(intervals[i++]);
            }

            while(i < intervals.Count && intervals[i].Start <= newInterval.End)
            {
                newInterval.Start = Math.Min(intervals[i].Start, newInterval.Start);
                newInterval.End = Math.Max(intervals[i].End, newInterval.End);
                i++;
            }

            mergedInterval.Add(newInterval);

            while (i < intervals.Count)
                mergedInterval.Add(intervals[i++]);


            return mergedInterval;
        }


        public static List<Interval> Merge(List<Interval> intervals)
        {
            if (intervals.Count < 2)
                return intervals;

            // sort the intervals by start time
            //Collections.sort(intervals, (a, b)->Integer.compare(a.start, b.start));

            intervals.Sort((a, b) => a.Start - b.Start);

            List<Interval> mergedIntervals = new List<Interval>();
            var start = intervals.First().Start;
            var end = intervals.First().End;

            for (var i = 1; i < intervals.Count; i++)
            {
                if (intervals[i].Start <= end)
                { // overlapping intervals, adjust the 'end'
                    end = Math.Max(intervals[i].End, end);
                }
                else
                { // non-overlapping interval, add the previous interval and reset
                    mergedIntervals.Add(new Interval(start, end));
                    start = intervals[i].Start;
                    end = intervals[i].End;
                }
            }
            // add the last interval
            mergedIntervals.Add(new Interval(start, end));

            return mergedIntervals;
        }

    }
}
