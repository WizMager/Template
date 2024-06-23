using System;

namespace Generator
{
    public class InstallAttribute : Attribute
    {
        public readonly EExecutionPriority Priority;
        public readonly int Order;

        public InstallAttribute(EExecutionPriority priority, int order)
        {
            Priority = priority;
            Order = order;
        }
    }
}