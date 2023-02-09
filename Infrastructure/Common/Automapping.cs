using AutoMapper;

namespace Infrastructure.Common
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            //CreateMap<Brand, BrandDto>().ReverseMap();
            ////CreateMap<BrandDto, Brand>();

            //CreateMap<Category, CategoryDto>().ReverseMap();
            ////CreateMap<CategoryDto, Category>();
            ////.ForMember(brand => brand.Brand,
            ////map => map.MapFrom(
            ////    b => new Brand
            ////    {
            ////        Name = b.BrandName
            ////    }));

            //CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            ////CreateMap<SubCategoryDto, SubCategory>();

            //CreateMap<Supplier, SupplierDto>().ReverseMap();
            ////CreateMap<SupplierDto, Supplier>();


            //CreateMap<ProductMasterEntry, ProductMasterEntryDto>().ReverseMap();
            ////CreateMap<ProductMasterEntryDto, ProductMasterEntry>();

            //CreateMap<ProductDetailEntry, ProductDetailEntryDto>().ReverseMap();
            ////CreateMap<ProductDetailEntryDto, ProductDetailEntry>();

            //CreateMap<ProductSaleMaster, ProductSaleMasterDto>().ReverseMap();
            ////CreateMap<ProductSaleMasterDto, ProductSaleMaster>();

            //CreateMap<ProductSaleDetail, ProductSaleDetailDto>().ReverseMap();
            ////CreateMap<ProductSaleDetailDto, ProductSaleDetail>();
        }
    }
}
