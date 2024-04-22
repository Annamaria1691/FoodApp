using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Title = categoryModel.Title,
                Active = categoryModel.Active,
                Promoted = categoryModel.Promoted
            };
        }

        public static Category ToCategoryFromCreatedDto(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                Title = categoryDto.Title,
                Active = categoryDto.Active,
                Promoted = categoryDto.Promoted
            };
        }




    }

}