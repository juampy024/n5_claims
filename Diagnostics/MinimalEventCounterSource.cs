﻿using System.Diagnostics.Tracing;

namespace N5_API.Project.Api.Diagnostics
{
    [EventSource(Name = "Sample.EventCounter.Minimal")]
    public sealed class MinimalEventCounterSource : EventSource
    {
        public static readonly MinimalEventCounterSource Log = new MinimalEventCounterSource();

        private EventCounter _requestCounter;

        private MinimalEventCounterSource() =>
            _requestCounter = new EventCounter("request-time", this)
            {
                DisplayName = "Request Processing Time",
                DisplayUnits = "ms"
            };

        public void Request(string url, float elapsedMilliseconds)
        {
            WriteEvent(1, url, elapsedMilliseconds);
            _requestCounter?.WriteMetric(elapsedMilliseconds);
        }

        protected override void Dispose(bool disposing)
        {
            _requestCounter?.Dispose();
            _requestCounter = null;

            base.Dispose(disposing);
        }
    }
}
