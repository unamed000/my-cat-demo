using System;

namespace MyOrg.Core
{
    public sealed class PreserveAttribute : System.Attribute {
        public bool AllMembers;
        public bool Conditional;
    }
}