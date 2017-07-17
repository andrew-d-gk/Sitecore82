namespace Sitecore82.Models.Core
{
    using System;

    using Glass.Mapper.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    /// <summary>
    /// The Sitecore children of templateId attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SitecoreChildrenOfTypeAttribute : SitecoreChildrenAttribute
    {
        /// <summary>
        /// The template id.
        /// </summary>
        private readonly string templateId;

        /// <summary>
        /// Initialises a new instance of the <see cref="SitecoreChildrenOfTypeAttribute"/> class.
        /// </summary>
        /// <param name="templateId">
        /// The templateId.
        /// </param>
        public SitecoreChildrenOfTypeAttribute(string templateId)
        {
            this.templateId = templateId;
        }

        /// <summary>
        /// Gets the template id.
        /// </summary>
        public string TemplateId
        {
            get
            {
                return this.templateId;
            }
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="propertyInfo">
        /// The property info.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractPropertyConfiguration"/>.
        /// </returns>
        public override AbstractPropertyConfiguration Configure(System.Reflection.PropertyInfo propertyInfo)
        {
            var config = new SitecoreChildrenOfTypeConfiguration(this.templateId);
            this.Configure(propertyInfo, config);
            return config;
        }
    }
}