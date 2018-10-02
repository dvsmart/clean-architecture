﻿using Q.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Q.Web.Models.Request
{
    public class GridRequest : IGridRequest
    {
        public GridRequest()
        {
            Page = Page ?? 1;
            PageSize = PageSize ?? 10;
        }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public string Filter { get; set; }

        public SortDirection SortDirection { get; set; }
    }

    public interface IFilter
    {
        Expression CreateFilterExpression(Expression instance);
    }

    public class SortDescriptor
    {
        public string Member { get; set; }

        public SortDirection SortDirection { get; set; }
    }

    public enum SortDirection
    {
        Ascending = 0,
        Descending = 1
    }
}
