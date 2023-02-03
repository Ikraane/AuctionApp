using Microsoft.AspNetCore.Mvc;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.Models;
using ProjectApp.ViewModels;
using System.Diagnostics;

namespace ProjectApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuctionService _auctionService;
        public HomeController(ILogger<HomeController> logger, IAuctionService auctionService)
        {
            _logger = logger;
            _auctionService = auctionService;
        }


        public IActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAll();
            List<AuctionVM> auctionVMs = new();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetByID(id);

            if (auction == null) return NotFound();

            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
        }

        public ActionResult CreateBid(int id)
        {
            return View();
        }

        // POST: AuctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid(CreateBidVM bvm, int id)
        {
            if (ModelState.IsValid)
            {
                Bid bid = new Bid(User.Identity.Name, bvm.Amount, DateTime.Now);
                _auctionService.AddBid(bid, id);
                return RedirectToAction("Index");
            }
            return View(bvm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult MyBids()
        {
            string username = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetAuctions(username);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View(auctionVMs);
        }

        public ActionResult MyWins()
        {
            string username = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetWins(username);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View(auctionVMs);
        }
    }
}