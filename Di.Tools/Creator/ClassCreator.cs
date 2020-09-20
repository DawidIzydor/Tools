using System;

namespace DiTools.Creator
{
    /// <summary>
    ///     Helps with creating classes
    /// </summary>
    public static class ClassCreatorHelper
    {
        /// <summary>
        ///     Creates a shadow-copy child object based on parent
        /// </summary>
        /// <param name="parent">Parent object to create copy from</param>
        /// <typeparam name="TChild"><c>Type</c> of child</typeparam>
        /// <typeparam name="TParent"><c>Type</c> of parent</typeparam>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns>Shadow copy of parent as child object</returns>
        public static TChild CreateChild<TChild, TParent>(this TParent parent) where TChild : TParent, new()
        {
            if (parent == null)
            {
                throw new NullReferenceException();
            }

            var child = new TChild();
            var childType = child.GetType();

            foreach (var propertyInfo in parent.GetType().GetProperties())
            {
                childType.GetProperty(propertyInfo.Name)?.SetValue(child, propertyInfo.GetValue(parent));
            }

            return child;
        }
    }
}