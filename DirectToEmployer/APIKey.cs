using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectToEmployer
{
    public static class APIKey
    {
        private static string googleDirectionsKey = "AIzaSyDy9oLGpYNwNjJlXpTwRgoq9JVA-mZ9Rp8";

        public static string GoogleDirectionsKey { get { return googleDirectionsKey; } }
    }
}