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
    
        public class ProductRepository : IProductRepository
    {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;

            public ProductRepository(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<ProductDTO> Create(ProductDTO objDTO)
            {
                var obj = _mapper.Map<ProductDTO, Product>(objDTO);
                var addedObj = _db.Products.Add(obj);
                await _db.SaveChangesAsync();

                return _mapper.Map<Product, ProductDTO>(addedObj.Entity);
            }

            public async Task<int> Delete(int id)
            {
                var obj = await _db.Products.FirstOrDefaultAsync(i => i.Id == id);
                if (obj != null)
                {
                    _db.Products.Remove(obj);
                    return await _db.SaveChangesAsync();
                }
                return 0;
            }
            public async Task<IEnumerable<ProductDTO>> GetAll()
            {
                return  _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(u => u.Category).Include(v => v.ProductPrices));
            }

            public async Task<ProductDTO> Get(int id)
            {
                var obj = await _db.Products.Include(u=>u.Category).Include(v=>v.ProductPrices).FirstOrDefaultAsync(i => i.Id == id);
                if (obj != null)
                {
                    return _mapper.Map<Product, ProductDTO>(obj);
                }
                return new ProductDTO();
            }

            public async Task<ProductDTO> Update(ProductDTO objDTO)
            {
                var objFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
                if (objFromDb != null)
                {
                    objFromDb.Name = objDTO.Name;
                    objFromDb.Description = objDTO.Description;
                    objFromDb.ImageUrl = objDTO.ImageUrl;
                    objFromDb.CategoryID = objDTO.CategoryID;
                    objFromDb.Color  = objDTO.Color;
                    objFromDb.ShopFavorites = objDTO.ShopFavorites;
                    objFromDb.CustomerFavorites = objDTO.CustomerFavorites;
                
                    _db.Products.Update(objFromDb);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Product, ProductDTO>(objFromDb);
                }
                return objDTO;
            }

        }
    
}
