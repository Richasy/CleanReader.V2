﻿using Clean_Reader.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuenov.SDK.Enums;

namespace Clean_Reader.Models.Core
{
    public partial class AppViewModel
    {
        public async Task WebCategoriesInit()
        {
            var response = await _yuenovClient.GetTotalCategoriesAsync();
            if (response.Result.Code == ResultCode.Success)
            {
                WebCategories.Clear();
                var categories = response.Data.Channels.SelectMany(p => p.Categories);
                foreach (var cate in categories)
                {
                    if (!WebCategories.Any(p => p.CategoryName == cate.CategoryName))
                    {
                        WebCategories.Add(cate);
                    }
                }
            }
        }
    }
}
