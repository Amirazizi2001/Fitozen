using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementLand.Application.Filters;
using SupplementLand.Application.Interfaces;
using SupplementLand.Infrastructure.Services;

namespace SupplementLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICatService _catService;
        private readonly IOfferService _offerService;
        private readonly IRateService _rateService;
        public HomePageController(IProductService productService, ICatService catService, IOfferService offerService, IRateService rateService)
        {
            _productService = productService;
            _catService = catService;
            _offerService = offerService;
            _rateService = rateService;
        }
        [HttpGet("NewProducts")]
        public async Task<IActionResult> GetNewProducts()
        {
            var products = await _productService.GetNewProductList();
            return Ok(products);
        }
        [HttpGet("GetProductDetail/{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var productDetail=await _productService.GetProductDetail(id);
            return Ok(productDetail);
        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var ctegories=await _catService.GetCategories();
            return Ok(ctegories);
        }
        [HttpGet("GetSpecialOffers")]
        public async Task<IActionResult> GetSpecialOffers([FromQuery]Filter filter)
        {
            var offers = await _offerService.GetSpecialOffers(filter);
            return Ok(offers);  
        }
        [HttpGet("GetOfferDtail/{id}")]
        public async Task<IActionResult> GetOfferDeatil(int id)
        {
            var detail = await _offerService.GetOfferDetail(id);
            return Ok(detail);
        }
        [HttpGet("GetProductsComment")]
        public async Task<IActionResult> GetProductComments([FromQuery]CommentFilter filter)
        {
            var comments = await _productService.GetProductComments(filter);
            return Ok(comments);
        }
        [HttpGet("GetProductRates")]
        public async Task<IActionResult> GetProductRates([FromQuery]RateFilter filter)
        {
            var rates = await _rateService.GetProductRates(filter);
            return Ok(rates);
        }
        [HttpGet("GetBestSellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var bestSellers=await _productService.GetBestSellers();
            return Ok(bestSellers);
        }


    }
}
