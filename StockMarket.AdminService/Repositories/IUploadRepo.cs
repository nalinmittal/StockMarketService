using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public interface IUploadRepo
    {
        void ImportExcel(string filePath);
    }
}
