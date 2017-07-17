namespace Sitecore82.Models.Core
{
    using Glass.Mapper.Sc.Configuration;

    /// <summary>
    /// The Sitecore children of type configuration.
    /// </summary>
    public class SitecoreChildrenOfTypeConfiguration : SitecoreChildrenConfiguration
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SitecoreChildrenOfTypeConfiguration"/> class.
        /// </summary>
        /// <param name="templateId">
        /// The template id.
        /// </param>
        public SitecoreChildrenOfTypeConfiguration(string templateId)
        {
            this.TemplateId = templateId;
        }

        /// <summary>
        /// Gets or sets the template id.
        /// </summary>
        public string TemplateId { get; set; }
    }
}