﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spite_Business.Repository.IRepository;
using Spite_DataAccess;
using Spite_DataAccess.Data;
using SpiteShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spite_Business.Repository
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductPriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductPriceDTO> Create(ProductPriceDTO objDTO)
        {
            var obj = _mapper.Map<ProductPriceDTO, ProductPrice>(objDTO);
            var addedObj = _db.ProductPrices.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductPrice, ProductPriceDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.ProductPrices.FirstOrDefaultAsync(i => i.ID == id);
            if (obj != null)
            {
                _db.ProductPrices.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<IEnumerable<ProductPriceDTO>> GetAll(int? id = null)
        {
            if(id != null && id > 0)
            {
              return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>
                    (_db.ProductPrices.Where(u=>u.ProductID == id));
            }
            else
            {
                return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>(_db.ProductPrices);
            }
        }

        public async Task<ProductPriceDTO> Get(int id)
        {
            var obj = await _db.ProductPrices.FirstOrDefaultAsync(i => i.ID == id);
            if (obj != null)
            {
                return _mapper.Map<ProductPrice, ProductPriceDTO>(obj);
            }
            return new ProductPriceDTO();
        }

        public async Task<ProductPriceDTO> Update(ProductPriceDTO objDTO)
        {
            var objFromDb = await _db.ProductPrices.FirstOrDefaultAsync(u => u.ID == objDTO.ID);
            if (objFromDb != null)
            {
                objFromDb.Size = objDTO.Size;
                objFromDb.Price = objDTO.Price;
                _db.ProductPrices.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<ProductPrice, ProductPriceDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
