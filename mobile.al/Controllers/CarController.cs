using Microsoft.AspNetCore.Mvc;
using mobile.al.Interfaces;
using mobile.al.Models;
using mobile.al.ViewModels;

namespace mobile.al.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarRepository _carRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CarController(ICarRepository carRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _carRepository = carRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carRepository.GetAll();
            return View(cars);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Car car = await _carRepository.GetByIdAsync(id);
            return View(car);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createCarViewModel = new CreateCarViewModel { AppUserId = curUserId };
            return View(createCarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                var uploadResults = await _photoService.AddPhotoAsync(carVM.Images);

                DateTime minDate = new DateTime(1980, 1, 1);
                DateTime maxDate = DateTime.Now;

                if (carVM.FirstRegistration < minDate || carVM.FirstRegistration > maxDate)
                {
                    ModelState.AddModelError("FirstRegistration", "First registration must be between 1980-01-01 and the current date");
                    return View(carVM);
                }

                var car = new Car
                {
                    Make = carVM.Make,
                    Category = carVM.Category,
                    Description = carVM.Description,
                    Price = carVM.Price,
                    Mileage = carVM.Mileage,
                    Photos = uploadResults.Select(result => new CarPhoto { Url = result.SecureUrl.AbsoluteUri }).ToList(),
                    FuelTypeCategory = carVM.FuelTypeCategory,
                    GearBoxCategory = carVM.GearBoxCategory,
                    Emission = carVM.Emission,
                    Interior = carVM.Interior,
                    Seller = carVM.Seller,
                    CreatedAt = DateTime.UtcNow,
                    FirstRegistration = carVM.FirstRegistration,
                    Accidented = carVM.Accidented,
                    Model = carVM.Model,
                    HorsePower = carVM.HorsePower,
                    Color = carVM.Color,
                    Extras = carVM.Extras,
                    NrOfOwners = carVM.NrOfOwners,
                    AppUserId = carVM.AppUserId,
                    Address = new Address
                    {
                        Street = carVM.Address.Street,
                        City = carVM.Address.City,
                        State = carVM.Address.State
                    }
                };
                _carRepository.Add(car);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(carVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) return View("Error");
            var carVM = new EditCarViewModel
            {
                Make = car.Make,
                Category = car.Category,
                Emission = car.Emission,
                Interior = car.Interior,
                Seller = car.Seller,
                Description = car.Description,
                Price = car.Price,
                Mileage = car.Mileage,
                AddressId = car.AddressId,
                Address = car.Address,
                URL = car.Photos,
                UpdatedAt = DateTime.UtcNow,
                FuelTypeCategory = car.FuelTypeCategory,
                GearBoxCategory = car.GearBoxCategory,
                Accidented = car.Accidented,
                Model = car.Model,
                NrOfOwners = car.NrOfOwners,
                HorsePower = car.HorsePower,
                Color = car.Color,
                Extras = car.Extras,
            };
            return View(carVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit car");
                return View("Edit", carVM);
            }

            var existingCar = await _carRepository.GetByIdAsyncNoTracking(id);

            if (existingCar != null)
            {
                try
                {
                    //await _photoService.DeletePhotoAsync(existingCar.PhotoUrls);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(carVM);
                }
                var uploadResults = await _photoService.AddPhotoAsync(carVM.Images);

                existingCar.Make = carVM.Make;
                existingCar.Category = carVM.Category;
                existingCar.Emission = carVM.Emission;
                existingCar.Interior = carVM.Interior;
                existingCar.Seller = carVM.Seller;
                existingCar.Description = carVM.Description;
                existingCar.Price = carVM.Price;
                existingCar.Mileage = carVM.Mileage;
                existingCar.UpdatedAt = DateTime.UtcNow;
                existingCar.FuelTypeCategory = carVM.FuelTypeCategory;
                existingCar.GearBoxCategory = carVM.GearBoxCategory;
                existingCar.Accidented = carVM.Accidented;
                existingCar.Model = carVM.Model;
                existingCar.HorsePower = carVM.HorsePower;
                existingCar.Color = carVM.Color;
                existingCar.NrOfOwners = carVM.NrOfOwners;
                existingCar.Extras = carVM.Extras;
                existingCar.AddressId = carVM.AddressId;
                existingCar.Address = carVM.Address;
                existingCar.Photos.AddRange(uploadResults.Select(result => new CarPhoto { Url = result.SecureUrl.AbsoluteUri }));

                _carRepository.Update(existingCar);

                return RedirectToAction("Index");
            }
            else
            {
                return View(carVM);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View("Error");
            return View(carDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View("Error");

            _carRepository.Delete(carDetails);
            return RedirectToAction("Index");
        }

    }
}
