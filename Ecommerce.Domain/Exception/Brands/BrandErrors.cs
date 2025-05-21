namespace Ecommerce.Domain.Exception.Brands
{
    public static class BrandErrors
    {
        public static readonly Error BrandNameIsNull = new Error("Brand.BrandName", "Brand name cannot be null");
    }
}
