﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Pipelines.DataMapperResolver;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.DataMappers;

namespace Glass.Mapper.Sc.Pipelines.DataMapper
{
    public class AbstractDataMapperFieldsWithSpace : AbstractDataMapperResolverTask
    {

        public AbstractDataMapperFieldsWithSpace()
        {
            Name = "DataMapperFieldsWithSpace"; 
        }
        public override void Execute(DataMapperResolverArgs args)
        {
            if (args.Result != null)
            {
                var fieldMapper = args.Result as AbstractSitecoreFieldMapper;

                if (fieldMapper != null)
                {
                    var scConfig = args.Result.Configuration as SitecoreFieldConfiguration;
                    scConfig.FieldName = GetFieldName(scConfig.FieldName);
                }
            }
            base.Execute(args);
        }

        protected virtual string GetFieldName(string fieldName)
        {
            return new string(InsertSpacesBeforeCaps(fieldName).ToArray()).Trim();
        }

        private IEnumerable<char> InsertSpacesBeforeCaps(IEnumerable<char> input)
        {
            foreach (char c in input)
            {
                if (char.IsUpper(c) || char.IsNumber(c))
                {
                    yield return ' ';
                }

                yield return c;
            }
        }
    }
}
