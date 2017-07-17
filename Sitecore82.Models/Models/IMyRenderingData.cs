namespace Sitecore82.Models.Models
{
    using Glass.Mapper.Sc.Configuration.Attributes;

    /// <summary>
    /// The My Rendering Data Template interface.
    /// </summary>
    [SitecoreType(TemplateId = "{A462CC8C-D788-4D81-9A61-D339F3A8F8FF}", AutoMap = true, Cachable = true)]
    public interface IMyRenderingData : IBaseModel
    {
        /// <summary>
        /// Gets or sets the Heading.
        /// </summary>
        [SitecoreField("Heading")]
        string Heading { get; set; }

        /// <summary>
        /// Gets or sets the SubHeading.
        /// </summary>
        [SitecoreField("SubHeading")]
        string SubHeading { get; set; }
    }
}
