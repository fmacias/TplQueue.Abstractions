using Fmacias.TplQueue.Contracts;
using System;

namespace Fmacias.TplQueue.Extensions
{
    /// <summary>
    /// Extension methods for job composition.
    /// </summary>
    public static class JobExtension
    {
        /// <summary>
        /// Declares that <paramref name="next"/> must run after <paramref name="previous"/>.
        /// This is equivalent to <c>next.After(previous)</c>.
        /// </summary>
        public static IJob Then(this IJob previous, IJob next)
        {
            if (previous == null) throw new ArgumentNullException(nameof(previous));
            if (next == null) throw new ArgumentNullException(nameof(next));
            return next.After(previous);
        }

        /// <summary>
        /// Declares that <paramref name="next"/> root must run after <paramref name="previous"/>.
        /// This supports chains that terminate in an enqueueable root.
        /// </summary>
        /// <param name="previous"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IJobRoot Then(this IJobNode previous, IJobRoot next)
        {
            if (previous == null) throw new ArgumentNullException(nameof(previous));
            if (next == null) throw new ArgumentNullException(nameof(next));
            return next.After(previous);
        }

        /// <summary>
        /// Declares that <paramref name="next"/> data job must run after
        /// <paramref name="previous"/>.
        /// </summary>
        public static IDataJob Then(this IDataJob previous, IDataJob next)
        {
            if (previous == null) throw new ArgumentNullException(nameof(previous));
            if (next == null) throw new ArgumentNullException(nameof(next));
            return next.After(previous);
        }

        /// <summary>
        /// Declares that <paramref name="next"/> data-job root must run after
        /// <paramref name="previous"/>.
        /// </summary>
        public static IDataJobRoot Then(this IDataJobNode previous, IDataJobRoot next)
        {
            if (previous == null) throw new ArgumentNullException(nameof(previous));
            if (next == null) throw new ArgumentNullException(nameof(next));
            return next.After(previous);
        }
    }
}
