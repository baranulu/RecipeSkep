using System;
using System.Collections.Generic;
using System.Text;

namespace LezizTariflerSepeti.Entity.PaginationModels
{
    public class RecipeParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 3;

		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}
