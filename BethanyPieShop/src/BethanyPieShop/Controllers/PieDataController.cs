using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    //it is a api controller(only return json data)
    [Route("api/[controller]")]
    public class PieDataController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieDataController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]  //api/PieData
        public IEnumerable<PieViewModel> LoadMorePies()
        {
           
            List<PieViewModel> pies = new List<PieViewModel>();
            try
            {
                IEnumerable<Pie> dbPies = null;
                dbPies = _pieRepository.Pies.OrderBy(p => p.PieId).Take(10);
            foreach (var dbPie in dbPies)
            {
                pies.Add(MapDbPieToPieViewModel(dbPie));
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pies;
        }
        [HttpGet("{Id}")] //api/PieData/2
        public IEnumerable<PieViewModel> LoadPiesbyId(int Id)
        {
            List<PieViewModel> pies = new List<PieViewModel>();
            IEnumerable<Pie> dbPies = null;
            try
            {

           // dbPies = _pieRepository.Pies.OrderBy(p => p.PieId).FirstOrDefault(p => p.PieId == Id);
            dbPies = _pieRepository.Pies.Where(c => c.PieId == Id)
                                                .OrderBy(p => p.Name);
            foreach (var dbPie in dbPies)
            {
                pies.Add(MapDbPieToPieViewModel(dbPie));
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pies;
        }

        private PieViewModel MapDbPieToPieViewModel(Pie dbPie)
        {
            return new PieViewModel()
            {
                PieId = dbPie.PieId,
                Name = dbPie.Name,
                Price = dbPie.Price,
                ShortDescription = dbPie.ShortDescription,
                ImageThumbnailUrl = dbPie.ImageThumbnailUrl
            };
        }
    }
}
