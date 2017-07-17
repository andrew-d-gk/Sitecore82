namespace Sitecore82.Models.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper;
    using Glass.Mapper.Configuration;
    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.DataMappers;

    using Sitecore.Data;
    using Sitecore.Data.Items;

    /// <summary>
    /// The Sitecore children of type cast mapper.
    /// </summary>
    public class SitecoreChildrenOfTypeMapper : SitecoreChildrenMapper
    {
        /// <summary>
        /// The is descendant of template.
        /// </summary>
        /// <param name="template">
        /// The template.
        /// </param>
        /// <param name="targetTemplate">
        /// The target template.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsDescendantOfTemplate(TemplateItem template, ID targetTemplate)
        {
            if (template == null)
            {
                return false;
            }

            var templates = BaseTemplates(template, new List<ID>());

            return templates.Any(id => id == targetTemplate);
        }

        /// <summary>
        /// The map to property.
        /// </summary>
        /// <param name="mappingContext">
        /// The mapping context.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public override object MapToProperty(AbstractDataMappingContext mappingContext)
        {
            var context = mappingContext as SitecoreDataMappingContext;
            var config = this.Configuration as SitecoreChildrenOfTypeConfiguration;

            if (context == null || config == null)
            {
                return null;
            }

            var genericType = Glass.Mapper.Utilities.GetGenericArgument(this.Configuration.PropertyInfo.PropertyType);
            var templateId = new ID(config.TemplateId);

            Func<IEnumerable<Item>> getItems =
                () =>
                    context.Item.Children.Where(
                        item => item.TemplateID == templateId || IsDescendantOfTemplate(item.Template, templateId));

            // changed to use Glass.Mapper.Utilities instead of  Glass.Mapper.sc.Utilities as resharper was complaining about static of derived types
            return Glass.Mapper.Utilities.CreateGenericType(
                typeof(LazyItemEnumerable<>),
                new[] { genericType },
                getItems,
                config.IsLazy,
                config.InferType,
                context.Service);
        }

        /// <summary>
        /// Setup the configurations that we can handle
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool CanHandle(AbstractPropertyConfiguration configuration, Context context)
        {
            return configuration is SitecoreChildrenOfTypeConfiguration;
        }

        /// <summary>
        /// Bases the templates.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="templates">The templates.</param>
        /// <returns>The list of IDs</returns>
        private static List<ID> BaseTemplates(TemplateItem template, List<ID> templates)
        {
            foreach (var baseTemplate in template.BaseTemplates)
            {
                if (templates.All(id => id != baseTemplate.ID))
                {
                    templates.Add(baseTemplate.ID);
                    BaseTemplates(baseTemplate, templates);
                }
            }

            return templates;
        }
    }
}