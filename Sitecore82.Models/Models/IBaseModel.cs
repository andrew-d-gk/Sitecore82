namespace Sitecore82.Models.Models
{
    using Sitecore.Globalization;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    /// <summary>
    /// The IBaseModel
    /// </summary>
    public interface IBaseModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [SitecoreId]
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the template identifier.
        /// </summary>
        /// <value>
        /// The template identifier.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        /// <value>
        /// The full path.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.FullPath)]
        string FullPath { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Path)]
        string Path { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Name)]
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.DisplayName)]
        string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Glass mapper requires this to be a string")]
        [SitecoreInfo(SitecoreInfoType.Url)]
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the full URL.
        /// </summary>
        /// <value>
        /// The full URL.
        /// </value>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Glass mapper requires this to be a string")]
        [SitecoreInfo(SitecoreInfoType.Url, UrlOptions = SitecoreInfoUrlOptions.AlwaysIncludeServerUrl | SitecoreInfoUrlOptions.LanguageEmbeddingNever)]
        string FullUrl { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Language)]
        Language Language { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [SitecoreInfo(SitecoreInfoType.Version)]
        int Version { get; set; }
    }

    /// <summary>
    /// Extension methods for the base model
    /// </summary>
    public static class BaseModelExtensions
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>the calculated display name</returns>
        public static string GetDisplayName(this IBaseModel model)
        {
            return !string.IsNullOrEmpty(model.DisplayName) ? model.DisplayName : model.Name;
        }

        /// <summary>
        /// Gets the URL - allowing for wildcard items.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="currentUrl">The current URL.</param>
        /// <returns>A string</returns>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Glass mapper requires this to be a string")]
        public static string GetUrl(this IBaseModel model, Uri currentUrl)
        {
            return !model.Name.Contains("*") ? model.Url : currentUrl.PathAndQuery;
        }
    }
}