﻿using Microsoft.OpenApi.Any;
using Onboarding_API.Models;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Services
{
    public interface ISaleService
    {
        Task<int> CreateSale(AddUpdateSaleVM model);
        Task<Sale?> GetSaleById(int id);
        Task<List<Sale>> GetSales();
        Task<List<DetailedSaleVM>> GetDetailedSales();
        Task<Sale> UpdateSale(Sale sale);
        Task DeleteSale(int id);
        bool SaleExists(int id);
    }
}
