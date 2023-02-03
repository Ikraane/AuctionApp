using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Core.Interfaces;
using ProjectApp.Core;
using ProjectApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ProjectApp.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: Auction. Returnerar en lista av alla auktioner
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            List<Auction> auctions = _auctionService.GetAllByUsername(username);
            List<AuctionVM> auctionVMs = new();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View(auctionVMs);
        }
        
        // GET: AuctionController/Details/5
        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetByID(id);

            if (auction == null) return NotFound();
            if (!auction.Seller.Equals(User.Identity.Name)) return BadRequest();

            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(auction);
            return View(detailsVM);
        }

        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVM vm)
        {
            if(ModelState.IsValid)
            {
                Auction auction = new Auction()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    Seller = User.Identity.Name,
                    AskPrice = vm.AskPrice,
                    CreateDate = DateTime.Now,
                    EndTime = vm.EndTime,

                };
                _auctionService.Add(auction);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        // GET: AuctionController/Edit/5
        [HttpGet]
        public ActionResult EditDescription(int id)
        {
            Auction auction = _auctionService.GetDescription(id);

            if (!auction.Seller.Equals(User.Identity.Name)) return BadRequest();
            EditVM editVM = EditVM.FromDescription(auction.Description);
            return View(editVM);
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDescription(EditVM evm, int id)
        {
            if (ModelState.IsValid)
            {
                Auction auction = new Auction(id, evm.Description);
                if (!auction.Seller.Equals(User.Identity.Name)) return BadRequest();
                _auctionService.EditDescription(auction);
                return RedirectToAction("Index");
            }
            return View(evm);
        }

      
    }
}
