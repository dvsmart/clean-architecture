﻿using System;
using System.Collections.Generic;

namespace Q.Domain
{
    public abstract class PagingRequestBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public class PagedResult<T> : PagingRequestBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }

    public interface IGridRequest
    {
        int? Page { get; set; }

        int? PageSize { get; set; }

        string Filter { get; set; }
        
    }

}
