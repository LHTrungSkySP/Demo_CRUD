﻿using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.Products.Dto
{
    public class ProductDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int? IdVoucher { get; set; } // Nullable int để cho phép giá trị null nếu không có voucher
        public string ImageUrl { get; set; }
        public string ImageList { get; set; } // Có thể dùng JSON hoặc CSV để lưu danh sách hình ảnh
        public int ViewCount { get; set; }
        public string SeoAlias { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public bool IsActive { get; set; }
        public decimal RateTotal { get; set; } // Tổng điểm đánh giá, có thể tính tổng điểm từ các đánh giá
        public int RateCount { get; set; } // Số lượng đánh giá
    }
}
