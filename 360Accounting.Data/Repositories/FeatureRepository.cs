﻿using _360Accounting.Core.Entities;
using _360Accounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _360Accounting.Data.Repositories
{
    public class FeatureRepository : Repository, IFeatureRepository
    {
        public Feature GetSingle(string id)
        {
            Feature feature = this.GetAll().FirstOrDefault(x => x.Id == Convert.ToInt32(id));
            return feature;
        }

        public IEnumerable<Feature> GetAll()
        {
            IEnumerable<Feature> featureList = this.Context.Features;
            return featureList;
        }

        public string Insert(Feature entity)
        {
            this.Context.Features.Add(entity);
            this.Commit();
            return entity.Id.ToString();
        }

        public string Update(Feature entity)
        {
            this.Context.Features.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Commit();
            return entity.Id.ToString();
        }

        public void Delete(string id)
        {
            this.Context.Features.Remove(this.GetSingle(id));
            this.Commit();
        }

        public int Count()
        {
            return this.GetAll().Count();
        }

        public int Commit()
        {
            return this.Context.SaveChanges();
        }
    }
}
